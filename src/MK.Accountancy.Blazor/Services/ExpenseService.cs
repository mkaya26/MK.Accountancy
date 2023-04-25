using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Expenses;
using MK.Accountancy.Invoices;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class ExpenseService : BaseService<ListExpenseDto,SelectExpenseDto>,IScopedDependency
    {
        public override void SelectEntity(IEntityDto targetEntity)
        {
            if (targetEntity is SelectInvoiceDetailDto moventInvoice)
            {
                moventInvoice.ExpenseId = SelectedItem.Id;
                moventInvoice.ExpenceCode = SelectedItem.Code;
                moventInvoice.ExpenceName = SelectedItem.Name;
                moventInvoice.UnitName = SelectedItem.UnitName;
                moventInvoice.UnitPrice = SelectedItem.UnitPrice;
                moventInvoice.TaxRate = SelectedItem.TaxRate;
            }
        }
    }
}
