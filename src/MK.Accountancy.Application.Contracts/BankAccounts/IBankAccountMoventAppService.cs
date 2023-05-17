using MK.Accountancy.Abstract;
using MK.Accountancy.PaymentDocuments;
using MK.Accountancy.Receipts;

namespace MK.Accountancy.BankAccounts
{
    public interface IBankAccountMoventAppService : ICrudAppService<SelectReceiptDetailDto,ListPaymentDocumentMoventDto,ReceiptDetailListParameterDto,ReceiptDetailDto,ReceiptDetailDto,ReceiptNumberParameterDto>
    {
    }
}
