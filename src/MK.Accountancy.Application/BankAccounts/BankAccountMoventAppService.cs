using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MK.Accountancy.Receipts;
using MK.Accountancy.PaymentDocuments;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using System.Diagnostics;
using Volo.Abp.Uow;

namespace MK.Accountancy.BankAccounts
{
    public class BankAccountMoventAppService : AccountancyAppService, IBankAccountMoventAppService
    {
        private readonly IReceiptDetailRepository _receiptDetailRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public BankAccountMoventAppService(IReceiptDetailRepository receiptDetailRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _receiptDetailRepository = receiptDetailRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<PagedResultDto<ListPaymentDocumentMoventDto>> GetListAsync(ReceiptDetailListParameterDto input)
        {
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
            {
                var movents = await _receiptDetailRepository.GetPagedListAsync(
                input.SkipCount,
                input.MaxResultCount,
                x => x.PaymentType == PaymentType.Bank ?
                x.BankAccountId == input.EntityId :
                x.SafeId == input.EntityId &&
                x.Receipt.DepartmentId == input.DepartmentId &&
                x.Receipt.TermId == input.TermId &&
                x.Receipt.Active,
                o => o.Receipt.ReceiptDate,
                i => i.Receipt);


                //
                var totalCount = await _receiptDetailRepository.CountAsync(
                    x => x.PaymentType == PaymentType.Bank ?
                    x.BankAccountId == input.EntityId :
                    x.SafeId == input.EntityId &&
                    x.Receipt.DepartmentId == input.DepartmentId &&
                    x.Receipt.TermId == input.TermId &&
                    x.Receipt.Active);
                //
                var mappedDtos = ObjectMapper.Map<List<ReceiptDetail>, List<ListPaymentDocumentMoventDto>>(movents);
                //
                mappedDtos.ForEach(x =>
                {
                    x.PaymentTypeName = L[$"Enum:PaymentType:{(byte)x.PaymentType}"];
                    x.ReceiptTypeName = L[$"Enum:ReceiptType:{(byte)x.ReceiptType}"];
                    x.DocumentStatuName = L[$"Enum:DocumentStatu:{(byte)x.DocumentStatu}"];
                });
                //
                await uow.CompleteAsync();
                //
                return new PagedResultDto<ListPaymentDocumentMoventDto>(totalCount, mappedDtos);
            }
        }

        public Task<SelectReceiptDetailDto> CreateAsync(ReceiptDetailDto input) => throw new NotImplementedException();

        public Task DeleteAsync(Guid id) => throw new NotImplementedException();

        public Task<SelectReceiptDetailDto> GetAsync(Guid id) => throw new NotImplementedException();

        public Task<string> GetCodeAsync(ReceiptNumberParameterDto input) => throw new NotImplementedException();
        public Task<SelectReceiptDetailDto> UpdateAsync(Guid id, ReceiptDetailDto input) => throw new NotImplementedException();
    }
}
