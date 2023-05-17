using MK.Accountancy.PaymentDocuments;
using MK.Accountancy.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Uow;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Safes
{
    public class SafeMoventAppService : AccountancyAppService, ISafeMoventAppService
    {
        private readonly IReceiptDetailRepository _receiptDetailRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SafeMoventAppService(IReceiptDetailRepository receiptDetailRepository, IUnitOfWorkManager unitOfWorkManager)
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
                x => x.SafeId == input.EntityId &&
                x.Receipt.DepartmentId == input.DepartmentId &&
                x.Receipt.TermId == input.TermId &&
                x.Receipt.Active,
                o => o.Receipt.ReceiptDate,
                i => i.Receipt);
                //
                var totalCount = await _receiptDetailRepository.CountAsync(
                    x => x.SafeId == input.EntityId &&
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
