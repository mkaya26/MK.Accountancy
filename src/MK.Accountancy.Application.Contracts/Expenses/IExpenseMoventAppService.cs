using MK.Accountancy.Abstract;
using MK.Accountancy.Invoices;

namespace MK.Accountancy.Expenses
{
    public interface IExpenseMoventAppService : ICrudAppService<SelectInvoiceDetailDto, ListExpenseMoventDto, ExpenseMoventListParameterDto, InvoiceDetailDto, InvoiceDetailDto, InvoiceNumberParameterDto>
    {
    }
}
