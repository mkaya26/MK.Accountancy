using MK.Accountancy.Receipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.PaymentDocuments
{
    public class PaymentDocumentAppService : AccountancyAppService, IPaymentDocumentAppService
    {
        private readonly IPaymentDocumentRepository _repository;

        public PaymentDocumentAppService(IPaymentDocumentRepository repository)
        {
            _repository = repository;
        }
        public async Task<PagedResultDto<ListPaymentDocumentDto>> GetListAsync(PaymentDocumentListParameterDto input)
        {
            IList<PaymentDocument> paymentDocuments;
            //
            if(input.Sql == "Sp_TransactionablePaymentDocuments")
            {
                paymentDocuments = await _repository.FromSqlRawAsync($"{input.Sql}  @DepartmentId = '{input.DepartmentId}', @TermId = '{input.TermId}', @MyDocument = {input.MyDocument}, @PaymentTypes = '{input.PaymentTypes}'");
            }
            else
            {
                paymentDocuments = await _repository.FromSqlRawAsync($"{input.Sql}  @DepartmentId = '{input.DepartmentId}', @TermId = '{input.TermId}', @PaymentTypes = '{input.PaymentTypes}'");
            }
            //
            var mappedEntities = ObjectMapper.Map<List<PaymentDocument>, List<ListPaymentDocumentDto>>(paymentDocuments.ToList());
            //
            mappedEntities.ForEach(x =>
            {
                x.PaymentTypeName = L[$"Enum:PaymentType:{(byte)x.PaymentType}"];
                x.DocumentStatuName = L[$"Enum:DocumentStatu:{(byte)x.DocumentStatu}"];
            });
            //
            return new PagedResultDto<ListPaymentDocumentDto>
            {
                TotalCount = paymentDocuments.Count,
                Items = mappedEntities
            };
        }

        public Task<SelectReceiptDetailDto> CreateAsync(ReceiptDetailDto input) => throw new NotImplementedException();

        public Task DeleteAsync(Guid id) => throw new NotImplementedException();

        public Task<SelectReceiptDetailDto> GetAsync(Guid id) => throw new NotImplementedException();

        public Task<string> GetCodeAsync(ReceiptNumberParameterDto input) => throw new NotImplementedException();

        public Task<SelectReceiptDetailDto> UpdateAsync(Guid id, ReceiptDetailDto input) => throw new NotImplementedException();
    }
}
