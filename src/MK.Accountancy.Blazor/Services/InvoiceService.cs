using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Invoices;
using MK.Blazor.Core.Services;
using System;
using System.Collections.Generic;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class InvoiceService : BaseService<ListInvoiceDto,SelectInvoiceDto>,IScopedDependency
    {
        public override void FillTable<TItem>(ICoreMoventService<TItem> moventService, Action hasChanged)
        {
            if(moventService is InvoiceMoventService invoiceMoventService)
            {
                invoiceMoventService.ListDataSource = DataSource.InvoiceDetails?? new List<SelectInvoiceDetailDto>();
                invoiceMoventService.HasChanged = hasChanged;
                invoiceMoventService.GetTotal();
            }
        }
    }
}
