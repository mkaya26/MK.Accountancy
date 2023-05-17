using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Stores;
using System.Linq;
using System.Threading.Tasks;

namespace MK.Accountancy.Blazor.Pages.Stores
{
    public partial class StoreMoventListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            Service.ListDataSource = (await GetListAsync(new StoreMoventListParameterDto
            {
                StoreId = Service.StoreId,
                DepartmentId = AppService.CompanyParameter.DepartmentId,
                TermId = AppService.CompanyParameter.TermId
            })).Items.ToList();
            //
            Service.IsLoaded = true;
        }
    }
}
