using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Invoices;
using MK.Accountancy.Services;
using System;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class ServiceMoventService : BaseService<ListServiceMoventDto, SelectInvoiceDetailDto>, IScopedDependency
    {
        public Guid ServiceId { get; set; }
        public InvoiceDetailType InvoiceDetailType { get; set; }
        public override void BeforeShowPopupListPage(params object[] parameters)
        {
            InvoiceDetailType = (InvoiceDetailType)parameters[0];
            ServiceId = (Guid)parameters[1];
            IsPopupListPage = true;
        }
    }
}
