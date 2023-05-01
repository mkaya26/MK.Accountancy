using MK.Accountancy.Abstract;
using MK.Accountancy.Receipts;

namespace MK.Accountancy.PaymentDocuments
{
    public interface IPaymentDocumentAppService : ICrudAppService<SelectReceiptDetailDto,ListPaymentDocumentDto,PaymentDocumentListParameterDto,ReceiptDetailDto,ReceiptDetailDto,ReceiptNumberParameterDto>
    {
    }
}
