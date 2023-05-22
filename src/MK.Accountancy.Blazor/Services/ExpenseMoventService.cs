using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Expenses;
using MK.Accountancy.Invoices;
using System;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class ExpenseMoventService : BaseService<ListExpenseMoventDto, SelectInvoiceDetailDto>, IScopedDependency
    {
        public Guid ExpenseId { get; set; }
        public InvoiceDetailType InvoiceDetailType { get; set; }
        public override void BeforeShowPopupListPage(params object[] parameters)
        {
            InvoiceDetailType = (InvoiceDetailType)parameters[0];
            ExpenseId = (Guid)parameters[1];
            IsPopupListPage = true;
        }
    }
}
