using MK.Accountancy.Invoices;
using MK.Accountancy.PaymentDocuments;
using MK.Accountancy.Receipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;
using static IdentityModel.OidcConstants;

namespace MK.Accountancy.Currents
{
    public class CurrentMoventAppService : AccountancyAppService, ICurrentMoventAppService
    {
        private readonly IReceiptDetailRepository _receiptDetailRepository;
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CurrentMoventAppService(IReceiptDetailRepository receiptDetailRepository, IInvoiceDetailRepository invoiceDetailRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _receiptDetailRepository = receiptDetailRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<PagedResultDto<ListCurrentMoventDto>> GetListAsync(CurrentMoventListParameterDto input)
        {
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
            {
                var receiptMovents = await _receiptDetailRepository.GetPagedListAsync(
                        input.SkipCount,
                        input.MaxResultCount,
                        x => x.Receipt.CurrentId == input.CurrentId &&
                        x.Receipt.DepartmentId == input.DepartmentId &&
                        x.Receipt.TermId == input.TermId &&
                        x.Receipt.Active,
                        o => o.Receipt.ReceiptDate,
                        i => i.Receipt);
                //
                var receiptTotalCount = await _receiptDetailRepository.CountAsync(
                    x => x.Receipt.CurrentId == input.CurrentId &&
                    x.Receipt.DepartmentId == input.DepartmentId &&
                    x.Receipt.TermId == input.TermId &&
                    x.Receipt.Active);
                //
                var mappedReceiptMoventDtos = ObjectMapper.Map<List<ReceiptDetail>, List<ListCurrentMoventDto>>(receiptMovents);
                //
                mappedReceiptMoventDtos.ForEach(x =>
                {
                    x.DocumentType = L["Receipt"];
                    x.MoventType = L[$"Enum:ReceiptType:{(byte)x.ReceiptType}"];
                });
                //
                var invoiceMovents = await _invoiceDetailRepository.GetPagedListAsync(
                        input.SkipCount,
                        input.MaxResultCount,
                        x => x.Invoice.CurrentId == input.CurrentId &&
                        x.Invoice.DepartmentId == input.DepartmentId &&
                        x.Invoice.TermId == input.TermId &&
                        x.Invoice.Active,
                        o => o.Invoice.InvoiceDate,
                        i => i.Invoice);
                //
                var invoiceTotalCount = await _invoiceDetailRepository.CountAsync(
                    x => x.Invoice.CurrentId == input.CurrentId &&
                    x.Invoice.DepartmentId == input.DepartmentId &&
                    x.Invoice.TermId == input.TermId &&
                    x.Invoice.Active);
                //
                var mappedInvoiceMoventDtos = ObjectMapper.Map<List<InvoiceDetail>, List<ListCurrentMoventDto>>(invoiceMovents);
                //
                mappedInvoiceMoventDtos.ForEach(x =>
                {
                    x.DocumentType = L["Invoice"];
                    x.MoventType = L[$"Enum:InvoiceType:{(byte)x.InvoiceType}"];
                });
                //
                await uow.CompleteAsync();
                //
                var items = mappedInvoiceMoventDtos.Concat(mappedReceiptMoventDtos).OrderBy(x => x.MoventDate).ToList();
                //
                return new PagedResultDto<ListCurrentMoventDto>(receiptTotalCount + invoiceTotalCount, items);
            }
        }
        public Task<SelectReceiptDetailDto> CreateAsync(ReceiptDetailDto input) => throw new NotImplementedException();

        public Task DeleteAsync(Guid id) => throw new NotImplementedException();

        public Task<SelectReceiptDetailDto> GetAsync(Guid id) => throw new NotImplementedException();

        public Task<string> GetCodeAsync(ReceiptNumberParameterDto input) => throw new NotImplementedException();

        public Task<SelectReceiptDetailDto> UpdateAsync(Guid id, ReceiptDetailDto input) => throw new NotImplementedException();
    }
}
