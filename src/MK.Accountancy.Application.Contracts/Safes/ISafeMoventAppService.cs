using MK.Accountancy.Abstract;
using MK.Accountancy.PaymentDocuments;
using MK.Accountancy.Receipts;

namespace MK.Accountancy.Safes
{
    public interface ISafeMoventAppService : ICrudAppService<SelectReceiptDetailDto, ListPaymentDocumentMoventDto, ReceiptDetailListParameterDto, ReceiptDetailDto, ReceiptDetailDto, ReceiptNumberParameterDto>
    {
    }
}
