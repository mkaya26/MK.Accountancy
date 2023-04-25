using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Invoices;
using MK.Accountancy.Stocks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class StockService : BaseService<ListStockDto,SelectStockDto>,IScopedDependency
    {
        public override void SelectEntity(IEntityDto targetEntity)
        {
            if(targetEntity is SelectInvoiceDetailDto moventInvoice)
            {
                moventInvoice.StockId = SelectedItem.Id;
                moventInvoice.StockCode = SelectedItem.Code;
                moventInvoice.StockName = SelectedItem.Name;
                moventInvoice.UnitName = SelectedItem.UnitName;
                moventInvoice.UnitPrice = SelectedItem.UnitPrice;
                moventInvoice.TaxRate = SelectedItem.TaxRate;
            }
        }
    }
}
