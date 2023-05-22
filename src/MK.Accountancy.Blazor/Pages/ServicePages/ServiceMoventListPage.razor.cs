using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Services;
using System.Linq;
using System.Threading.Tasks;

namespace MK.Accountancy.Blazor.Pages.ServicePages
{
    public partial class ServiceMoventListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            Service.ListDataSource = (await GetListAsync(new ServiceMoventListParameterDto
            {
                ServiceId = Service.ServiceId,
                InvoiceDetailType = Service.InvoiceDetailType,
                DepartmentId = AppService.CompanyParameter.DepartmentId,
                TermId = AppService.CompanyParameter.TermId
            })).Items.ToList();
            //
            Service.IsLoaded = true;
        }
    }
}
