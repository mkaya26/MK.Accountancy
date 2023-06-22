using Microsoft.AspNetCore.Authorization;
using MK.Accountancy.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace MK.Accountancy.Receipts
{
    [Authorize(AccountancyPermissions.Receipt.Default)]
    public class ReceiptAppService : AccountancyAppService, IReceiptAppService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly ReceiptManager _receiptManager;
        private readonly ReceiptDetailManager _receiptDetailManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ReceiptAppService(IReceiptRepository receiptRepository, ReceiptManager receiptManager, ReceiptDetailManager receiptDetailManager, IUnitOfWorkManager unitOfWorkManager)
        {
            _receiptRepository = receiptRepository;
            _receiptManager = receiptManager;
            _receiptDetailManager = receiptDetailManager;
            _unitOfWorkManager = unitOfWorkManager;
        }
        [Authorize(AccountancyPermissions.Receipt.Create)]
        public virtual async Task<SelectReceiptDto> CreateAsync(CreateReceiptDto input)
        {
            await _receiptManager.CheckCreateAsync(input.ReceiptNumber, input.ReceiptType, input.CurrentId, input.SpecialCodeOneId, input.SpecialCodeTwoId, input.DepartmentId, input.TermId, input.SafeId, input.BankAccountId);
            //
            foreach(var receiptDetail in input.ReceiptDetails)
            {
                await _receiptDetailManager.CheckCreateAsync(receiptDetail.ChequeBankId, receiptDetail.ChequeBankDepartmentId, receiptDetail.SafeId, receiptDetail.BankAccountId);
            }
            //
            var entity = ObjectMapper.Map<CreateReceiptDto, Receipt>(input);
            await _receiptRepository.InsertAsync(entity);
            return ObjectMapper.Map<Receipt, SelectReceiptDto>(entity);
        }
        [Authorize(AccountancyPermissions.Receipt.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await _receiptRepository.GetAsync(id, f => f.Id == id, i => i.ReceiptDetails);
            //
            await _receiptRepository.DeleteAsync(entity);
            entity.ReceiptDetails.RemoveAll(entity.ReceiptDetails);
        }

        public virtual async Task<SelectReceiptDto> GetAsync(Guid id)
        {
            var entity = await _receiptRepository.GetAsync(id, x => x.Id == id);
            var mappedDto = ObjectMapper.Map<Receipt, SelectReceiptDto>(entity);
            //
            mappedDto.receiptDetails.ForEach(x =>
           {
               x.PaymentTypeName = L[$"Enum:PaymentType:{(byte)x.PaymentType}"];
               x.DocumentStatuName = L[$"Enum:DocumentStatu:{(byte)x.DocumentStatu}"];
           });
            return mappedDto;
        }

        public virtual async Task<string> GetCodeAsync(ReceiptNumberParameterDto input)
        {
            return await _receiptRepository.GetCodeAsync(p => p.ReceiptNumber, f => f.ReceiptType == input.ReceiptType && f.DepartmentId == input.DepartmentId && f.TermId == input.TermId);
        }

        public virtual async Task<PagedResultDto<ListReceiptDto>> GetListAsync(ReceiptListParameterDto input)
        {
            var entities = await _receiptRepository.GetPagedListAsync(
                                    input.SkipCount,
                                    input.MaxResultCount,
                                    f => f.ReceiptType == input.ReceiptType &&
                                         f.DepartmentId == input.DepartmentId &&
                                         f.TermId == input.TermId &&
                                         f.Active == input.Active,
                                    o => o.ReceiptNumber,
                                    i => i.Current,
                                    i => i.Safe,
                                    i => i.BankAccount,
                                    i => i.SpecialCodeOne,
                                    i => i.SpecialCodeTwo);
            //
            var totalCount = await _receiptRepository.CountAsync(
                                    f => f.ReceiptType == input.ReceiptType &&
                                         f.DepartmentId == input.DepartmentId &&
                                         f.TermId == input.TermId &&
                                         f.Active == input.Active);
            //
            return new PagedResultDto<ListReceiptDto>(totalCount, ObjectMapper.Map<List<Receipt>, List<ListReceiptDto>>(entities));
        }
        [Authorize(AccountancyPermissions.Receipt.Update)]
        public async Task<SelectReceiptDto> UpdateAsync(Guid id, UpdateReceiptDto input)
        {
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
            {
                var entity = await _receiptRepository.GetAsync(id, f => f.Id == id, i => i.ReceiptDetails);
            //

                await _receiptManager.CheckUpdateAsync(id, input.ReceiptNumber, entity, input.SpecialCodeOneId, input.SpecialCodeTwoId, input.CurrentId, input.SafeId, input.BankAccountId);
                //
                foreach (var itemDetail in input.ReceiptDetails)
                {
                    await _receiptDetailManager.CheckUpdateAsync(itemDetail.ChequeBankId, itemDetail.ChequeBankDepartmentId, itemDetail.SafeId, itemDetail.BankAccountId);
                    //
                    var receiptDetail = entity.ReceiptDetails.FirstOrDefault(x => x.Id == itemDetail.Id);
                    //
                    if (receiptDetail == null)
                    {
                        entity.ReceiptDetails.Add(ObjectMapper.Map<ReceiptDetailDto, ReceiptDetail>(itemDetail));
                        continue;
                    }
                    //
                    ObjectMapper.Map(itemDetail, receiptDetail);
                }
                //
                var deletedEntities = entity.ReceiptDetails.Where(f => input.ReceiptDetails.Select(x => x.Id).ToList().IndexOf(f.Id) == -1);
                //
                entity.ReceiptDetails.RemoveAll(deletedEntities);
                //
                ObjectMapper.Map(input, entity);
                //
                await _receiptRepository.UpdateAsync(entity);
                //
                await uow.CompleteAsync();
                //
                return ObjectMapper.Map<Receipt, SelectReceiptDto>(entity);
            }
        }
    }
}
