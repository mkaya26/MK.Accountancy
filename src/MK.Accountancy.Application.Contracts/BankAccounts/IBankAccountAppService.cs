using MK.Accountancy.Abstract;

namespace MK.Accountancy.BankAccounts
{
    public interface IBankAccountAppService : ICrudAppService<SelectBankAccountDto,ListBankAccountDto,BankAccountListParameterDto,CreateBankAccountDto,UpdateBankAccountDto,BankAccountCodeParameterDto>
    {
    }
}
