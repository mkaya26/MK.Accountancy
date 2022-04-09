using MK.Accountancy.Abstract;

namespace MK.Accountancy.Receipts
{
    public interface IReceiptAppService : ICrudAppService<SelectReceiptDto, ListReceiptDto, ReceiptListParameterDto, CreateReceiptDto, UpdateReceiptDto, ReceiptNumberParameterDto>
    {
    }
}
