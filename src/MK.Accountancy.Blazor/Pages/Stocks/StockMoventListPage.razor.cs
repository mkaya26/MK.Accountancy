using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Stocks;
using System.Linq;
using System.Threading.Tasks;

namespace MK.Accountancy.Blazor.Pages.Stocks
{
    public partial class StockMoventListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            Service.ListDataSource = (await GetListAsync(new StockMoventListParameterDto
            {
                EntityId = Service.StockId,
                InvoiceDetailType = Service.InvoiceDetailType,
                DepartmentId = AppService.CompanyParameter.DepartmentId,
                TermId = AppService.CompanyParameter.TermId
            })).Items.ToList();
            //
            Service.IsLoaded = true;
        }
    }
}
