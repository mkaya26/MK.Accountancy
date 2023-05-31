using Microsoft.AspNetCore.Authorization;
using MK.Accountancy.CommonDtos;
using MK.Accountancy.Invoices;
using MK.Accountancy.Permissions;
using MK.Accountancy.Receipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Currents
{
    [Authorize(AccountancyPermissions.Current.Default)]
    public class CurrentAppService : AccountancyAppService, ICurrentAppService
    {
        private readonly ICurrentRepository _currentRepository;
        private readonly CurrentManager _currentManager;

        public CurrentAppService(ICurrentRepository currentRepository, CurrentManager currentManager)
        {
            _currentRepository = currentRepository;
            _currentManager = currentManager;
        }
        [Authorize(AccountancyPermissions.Current.Create)]
        public virtual async Task<SelectCurrentDto> CreateAsync(CreateCurrentDto input)
        {
            await _currentManager.CheckCreateAsync(input.Code, input.SpecialCodeOneId, input.SpecialCodeTwoId);
            //
            var entity = ObjectMapper.Map<CreateCurrentDto, Current>(input);
            await _currentRepository.InsertAsync(entity);
            return ObjectMapper.Map<Current, SelectCurrentDto>(entity);
        }
        [Authorize(AccountancyPermissions.Current.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _currentManager.CheckDeleteAsync(id);
            //
            await _currentRepository.DeleteAsync(id);
        }

        public virtual async Task<SelectCurrentDto> GetAsync(Guid id)
        {
            var entity = await _currentRepository.GetAsync(id, x => x.Id == id, i => i.SpecialCodeOne, i => i.SpecialCodeTwo);
            return ObjectMapper.Map<Current, SelectCurrentDto>(entity);
        }

        public virtual async Task<string> GetCodeAsync(CodeParameterDto input)
        {
            return await _currentRepository.GetCodeAsync(s => s.Code, f => f.Active == input.Active);
        }

        public virtual async Task<PagedResultDto<ListCurrentDto>> GetListAsync(CurrentListParameterDto input)
        {
            var entities = await _currentRepository.GetPagedListAsync(
                                                    input.SkipCount,
                                                    input.MaxResultCount,
                                                    f => f.Active == input.Active,
                                                    s => s.Code,
                                                    i => i.SpecialCodeOne,
                                                    i => i.SpecialCodeTwo,
                                                    i => i.Invoices,
                                                    i => i.Receipts);
            //
            var totalCount = await _currentRepository.CountAsync(f => f.Active == input.Active);
            //
            var mappedDtos = ObjectMapper.Map<List<Current>, List<ListCurrentDto>>(entities);
            //
            mappedDtos.ForEach(i =>
            {
                i.Receivable = i.Invoices.Where(y => y.InvoiceType == InvoiceType.Buy).Sum(y => y.Netamount);
                i.Receivable += i.Receipts
                         .Where(y => y.ReceiptType == ReceiptType.Collection)
                         .Sum(y => 
                            y.ChequeTotal + y.BillTotal + y.PostTotal + y.CashTotal + y.BankTotal);
                //
                i.Debt = i.Invoices.Where(y => y.InvoiceType == InvoiceType.Sell).Sum(y => y.Netamount);
                i.Debt += i.Receipts
                                    .Where(y => y.ReceiptType == ReceiptType.Payment)
                                    .Sum(y =>
                                     y.ChequeTotal + y.BillTotal + y.PostTotal + y.CashTotal + y.BankTotal);
            });
            //
            return new PagedResultDto<ListCurrentDto>(totalCount, mappedDtos);
        }
        [Authorize(AccountancyPermissions.Current.Update)]
        public virtual async Task<SelectCurrentDto> UpdateAsync(Guid id, UpdateCurrentDto input)
        {
            var entity = await _currentRepository.GetAsync(id, f => f.Id == id);
            //
            await _currentManager.CheckUpdateAsync(id, input.Code, entity, input.SpecialCodeOneId, input.SpecialCodeTwoId);
            //
            var mappedEntity = ObjectMapper.Map(input, entity);
            await _currentRepository.UpdateAsync(mappedEntity);
            return ObjectMapper.Map<Current, SelectCurrentDto>(mappedEntity);
        }
    }
}
