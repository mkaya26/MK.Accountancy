using Microsoft.AspNetCore.Authorization;
using MK.Accountancy.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Invoices
{
    [Authorize(AccountancyPermissions.Invoice.Default)]
    public class InvoiceAppService : AccountancyAppService, IInvoiceAppService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceManager _invoiceManager;
        private readonly InvoiceDetailManager _invoiceDetailManager;

        public InvoiceAppService(IInvoiceRepository invoiceRepository, InvoiceManager invoiceManager, InvoiceDetailManager invoiceDetailManager)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceManager = invoiceManager;
            _invoiceDetailManager = invoiceDetailManager;
        }
        [Authorize(AccountancyPermissions.Invoice.Create)]
        public virtual async Task<SelectInvoiceDto> CreateAsync(CreateInvoiceDto input)
        {
            await _invoiceManager.CheckCreateAsync(input.InvoiceNumber, input.CurrentId, input.SpecialCodeOneId, input.SpecialCodeTwoId, input.DepartmentId, input.TermId);
            foreach(var invoiceDetail in input.InvoiceDetails)
            {
                await _invoiceDetailManager.CheckCreateAsync(invoiceDetail.StockId, invoiceDetail.ServiceId, invoiceDetail.ExpenseId, invoiceDetail.StoreId);
            }
            //
            var entity = ObjectMapper.Map<CreateInvoiceDto, Invoice>(input);
            //
            await _invoiceRepository.InsertAsync(entity);
            //
            return ObjectMapper.Map<Invoice,SelectInvoiceDto>(entity);
        }
        [Authorize(AccountancyPermissions.Invoice.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await _invoiceRepository.GetAsync(id, f => f.Id == id, i => i.InvoiceDetails);
            await _invoiceRepository.DeleteAsync(entity);
            entity.InvoiceDetails.RemoveAll(entity.InvoiceDetails);
        }

        public virtual async Task<SelectInvoiceDto> GetAsync(Guid id)
        {
            var entity = await _invoiceRepository.GetAsync(id, f => f.Id == id);
            //
            var mappedDto = ObjectMapper.Map<Invoice,SelectInvoiceDto>(entity);
            mappedDto.InvoiceDetails.ForEach(x =>
            {
                x.InvoiceDetailTypeName = L[$"Enum:InvoiceDetailType:{(byte)x.InvoiceDetailType}"];
            });
            //
            return mappedDto;
        }

        public async Task<string> GetCodeAsync(InvoiceNumberParameterDto input)
        {
            return await _invoiceRepository.GetCodeAsync(s => s.InvoiceNumber,
                                                       f => f.InvoiceType == input.InvoiceType &&
                                                            f.DepartmentId == input.DepartmentId &&
                                                            f.TermId == input.TermId &&
                                                            f.Active == input.Active);
        }

        public virtual async Task<PagedResultDto<ListInvoiceDto>> GetListAsync(InvoiceListParameterDto input)
        {
            var entities = await _invoiceRepository.GetPagedListAsync(
                                input.SkipCount,
                                input.MaxResultCount,
                                f => f.InvoiceType == input.InvoiceType &&
                                     f.DepartmentId == input.DepartmentId &&
                                     f.TermId == input.TermId &&
                                     f.Active == input.Active,
                                o => o.InvoiceNumber,
                                i => i.Current,
                                i => i.SpecialCodeOne,
                                i => i.SpecialCodeTwo);
            //
            var totalCount = await _invoiceRepository.CountAsync(
                                f => f.InvoiceType == input.InvoiceType &&
                                     f.DepartmentId == input.DepartmentId &&
                                     f.TermId == input.TermId &&
                                     f.Active == input.Active);
            //
            return new PagedResultDto<ListInvoiceDto>(totalCount, ObjectMapper.Map<List<Invoice>, List<ListInvoiceDto>>(entities));
        }
        [Authorize(AccountancyPermissions.Invoice.Update)]
        public virtual async Task<SelectInvoiceDto> UpdateAsync(Guid id, UpdateInvoiceDto input)
        {
            var entity = await _invoiceRepository.GetAsync(id, x => x.Id == id, i => i.InvoiceDetails);
            //
            await _invoiceManager.CheckUpdateAsync(id, input.InvoiceNumber, entity, input.SpecialCodeOneId, input.SpecialCodeTwoId, input.CurrentId);
            //
            foreach(var item in input.InvoiceDetails)
            {
                await _invoiceDetailManager.CheckUpdateAsync(item.StockId, item.ServiceId, item.ExpenseId, item.StoreId);
                //
                var invoiceDetail = entity.InvoiceDetails.FirstOrDefault(f => f.Id == item.Id);
                //
                if(invoiceDetail == null)
                {
                    entity.InvoiceDetails.Add(ObjectMapper.Map<InvoiceDetailDto, InvoiceDetail>(item));
                    continue;
                }
                //
                ObjectMapper.Map(item, invoiceDetail);
            }
            //
            var deletedEntities = entity.InvoiceDetails.Where(i =>
                                         input.InvoiceDetails.Select(c => c.Id).ToList().IndexOf(i.Id) == -1);
            entity.InvoiceDetails.RemoveAll(deletedEntities);
            //
            ObjectMapper.Map(input, entity);
            //
            await _invoiceRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Invoice, SelectInvoiceDto>(entity);
        }
    }
}
