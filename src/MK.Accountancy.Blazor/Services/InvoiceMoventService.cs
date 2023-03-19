﻿using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Invoices;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class InvoiceMoventService : BaseMoventService<SelectInvoiceDetailDto>, IScopedDependency
    {
    }
}
