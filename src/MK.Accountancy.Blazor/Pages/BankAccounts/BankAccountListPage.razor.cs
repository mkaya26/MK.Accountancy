using MK.Accountancy.BankAccounts;
using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Parameters;
using System.Linq;
using System.Threading.Tasks;

namespace MK.Accountancy.Blazor.Pages.BankAccounts
{
    public partial class BankAccountListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            Service.ListDataSource = (await GetListAsync(new BankAccountListParameterDto
            {
                BankAccountType = Service.BankAccountType,
                DepartmentId = AppService.CompanyParameter.DepartmentId,
                Active = Service.IsActiveCards
            })).Items.ToList();
            //
            Service.IsLoaded = true;
        }

        protected override async Task BeforeInsertAsync()
        {
            Service.DataSource = new SelectBankAccountDto
            {
                Code = await GetCodeAsync(new BankAccountCodeParameterDto
                {
                     DepartmentId = ((SelectOrganizationParameterDto)AppService.CompanyParameter).DepartmentId,
                    Active = Service.IsActiveCards
                }),
                BankAccountType = BankAccountType.CurrentDepositAccount,
                DepartmentId = ((SelectOrganizationParameterDto)AppService.CompanyParameter).DepartmentId,
                Active = Service.IsActiveCards
            };
            //
            Service.ShowEditPage();
        }
    }
}
