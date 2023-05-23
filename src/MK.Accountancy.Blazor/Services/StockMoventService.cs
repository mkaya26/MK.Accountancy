using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Invoices;
using MK.Accountancy.Stocks;
using System;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class StockMoventService : BaseService<ListStockMoventDto, SelectInvoiceDetailDto>, IScopedDependency
    {
        public Guid StockId { get; set; }
        public InvoiceDetailType InvoiceDetailType { get; set; }
        public override void BeforeShowPopupListPage(params object[] parameters)
        {
            InvoiceDetailType = (InvoiceDetailType)parameters[0];
            StockId = (Guid)parameters[1];
            IsPopupListPage = true;
        }
    }
}
