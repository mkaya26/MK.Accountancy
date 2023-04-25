using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Invoices;
using MK.Accountancy.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class ServiceService : BaseService<ListServiceDto,SelectServiceDto>,IScopedDependency
    {
        public override void SelectEntity(IEntityDto targetEntity)
        {
            if (targetEntity is SelectInvoiceDetailDto moventInvoice)
            {
                moventInvoice.ServiceId = SelectedItem.Id;
                moventInvoice.ServiceCode = SelectedItem.Code;
                moventInvoice.ServiceName = SelectedItem.Name;
                moventInvoice.UnitName = SelectedItem.UnitName;
                moventInvoice.UnitPrice = SelectedItem.UnitPrice;
                moventInvoice.TaxRate = SelectedItem.TaxRate;
            }
        }
    }
}
