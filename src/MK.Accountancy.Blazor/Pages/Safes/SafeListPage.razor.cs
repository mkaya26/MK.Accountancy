using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Parameters;
using System.Linq;
using System.Threading.Tasks;

namespace MK.Accountancy.Blazor.Pages.Safes
{
    public partial class SafeListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            Service.ListDataSource = (await GetListAsync(new MK.Accountancy.Safes.SafeListParameterDto
            {
                DepartmentId = ((SelectOrganizationParameterDto)AppService.CompanyParameter).DepartmentId,
                Active = Service.IsActiveCards
            })).Items.ToList();
            //
            Service.IsLoaded = true;
        }

        protected override async Task BeforeInsertAsync()
        {
            Service.DataSource = new MK.Accountancy.Safes.SelectSafeDto
            {
                Code = await GetCodeAsync(new MK.Accountancy.Safes.SafeCodeParameterDto
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
