using MK.Accountancy.BankDepartments;
using System.Linq;
using System.Threading.Tasks;

namespace MK.Accountancy.Blazor.Pages.BankDepartments
{
    public partial class BankDepartmentListPage
    {
        protected override async Task GetListDataSourceAsync()
        {
            Service.ListDataSource = (await GetListAsync(new BankDepartmentListParameterDto
            {
                BankId = Service.BankId,
                Active = Service.IsActiveCards
            })).Items.ToList();
            //
            Service.IsLoaded = true;
        }

        protected override async Task BeforeInsertAsync()
        {
            Service.DataSource = new SelectBankDepartmentDto
            {
                Code = await GetCodeAsync(new BankDepartmentCodeParameterDto
                {
                    BankId = Service.BankId,
                    Active = Service.IsActiveCards
                }),
                BankId = Service.BankId,
                Active = Service.IsActiveCards
            };
            //
            Service.ShowEditPage();
        }
    }
}
