using MK.Accountancy.Abstract;
using MK.Accountancy.Receipts;

namespace MK.Accountancy.Currents
{
    public interface ICurrentMoventAppService : ICrudAppService<SelectReceiptDetailDto, ListCurrentMoventDto, CurrentMoventListParameterDto, ReceiptDetailDto, ReceiptDetailDto, ReceiptNumberParameterDto>
    {
    }
}
