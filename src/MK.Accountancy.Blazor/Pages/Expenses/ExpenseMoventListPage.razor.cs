using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Expenses;
using System.Linq;
using System.Threading.Tasks;

namespace MK.Accountancy.Blazor.Pages.Expenses
{
    public partial class ExpenseMoventListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            Service.ListDataSource = (await GetListAsync(new ExpenseMoventListParameterDto
            {
                ExpenseId = Service.ExpenseId,
                InvoiceDetailType = Service.InvoiceDetailType,
                DepartmentId = AppService.CompanyParameter.DepartmentId,
                TermId = AppService.CompanyParameter.TermId
            })).Items.ToList();
            //
            Service.IsLoaded = true;
        }
    }
}
