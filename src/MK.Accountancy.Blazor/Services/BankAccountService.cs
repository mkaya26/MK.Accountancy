using MK.Accountancy.BankAccounts;
using MK.Accountancy.Blazor.Services.Base;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class BankAccountService : BaseService<ListBankAccountDto, SelectBankAccountDto>,
    IScopedDependency
    {
        public BankAccountType? BankAccountType { get; set; }


    }
}
