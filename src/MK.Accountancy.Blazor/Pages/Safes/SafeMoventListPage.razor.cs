using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Receipts;
using System.Linq;
using System.Threading.Tasks;

namespace MK.Accountancy.Blazor.Pages.Safes
{
    public partial class SafeMoventListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            Service.ListDataSource = (await GetListAsync(new ReceiptDetailListParameterDto
            {
                PaymentType = Service.PaymentType,
                EntityId = Service.EntityId,
                DepartmentId = AppService.CompanyParameter.DepartmentId,
                TermId = AppService.CompanyParameter.TermId
            })).Items.ToList();
            //
            Service.IsLoaded = true;
        }
    }
}
