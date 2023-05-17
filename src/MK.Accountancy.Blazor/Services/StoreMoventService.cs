using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Invoices;
using MK.Accountancy.Stocks;
using System;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class StoreMoventService : BaseService<ListStockMoventDto,SelectInvoiceDetailDto>,IScopedDependency
    {
        public Guid StoreId { get; set; }
        public override void BeforeShowPopupListPage(params object[] parameters)
        {
            StoreId = (Guid)parameters[0];
            IsPopupListPage = true;
        }
    }
}
