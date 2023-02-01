using MK.Accountancy.BankAccounts;
using MK.Accountancy.Blazor.Services.Base;
using MK.Blazor.Core.Models;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class BankAccountService : BaseService<ListBankAccountDto, SelectBankAccountDto>,
    IScopedDependency
    {
        public BankAccountType? BankAccountType { get; set; }
        public void BankAccountTypeSelectedItemChanged(ComboboxEnumItem<BankAccountType> selectedItem)
        {
            DataSource.BankAccountType = selectedItem.Value;
        }
    }
}
