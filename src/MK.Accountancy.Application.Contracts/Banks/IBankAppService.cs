using MK.Accountancy.Abstract;
using MK.Accountancy.CommonDtos;

namespace MK.Accountancy.Banks
{
    public interface IBankAppService : ICrudAppService<SelectBankDto, BankListDto, BankListParameterDto, CreateBankDto, UpdateBankDto, CodeParameterDto>
    {
    }
}
