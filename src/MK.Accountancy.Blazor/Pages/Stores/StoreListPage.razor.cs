using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Parameters;
using MK.Accountancy.Stores;
using System.Threading.Tasks;
using System.Linq;

namespace MK.Accountancy.Blazor.Pages.Stores
{
    public partial class StoreListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            Service.ListDataSource = (await GetListAsync(new StoreListParameterDto
            {
                DepartmentId = ((SelectOrganizationParameterDto)AppService.CompanyParameter).DepartmentId,
                Active = Service.IsActiveCards
            })).Items.ToList();
            //
            Service.IsLoaded = true;
        }

        protected override async Task BeforeInsertAsync()
        {
            Service.DataSource = new SelectStoreDto
            {
                Code = await GetCodeAsync(new StoreCodeParameterDto
                {
                    DepartmentId = ((SelectOrganizationParameterDto)AppService.CompanyParameter).DepartmentId,
                    Active = Service.IsActiveCards
                }),
                DepartmentId = ((SelectOrganizationParameterDto)AppService.CompanyParameter).DepartmentId,
                Active = Service.IsActiveCards
            };
            //
            Service.ShowEditPage();
        }
    }
}
