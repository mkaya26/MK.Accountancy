using MK.Accountancy.Abstract;
using MK.Accountancy.Invoices;

namespace MK.Accountancy.Stocks
{
    public interface IStockMoventAppService : ICrudAppService<SelectInvoiceDetailDto, ListStockMoventDto, StockMoventListParameterDto, InvoiceDetailDto, InvoiceDetailDto, InvoiceNumberParameterDto>
    {
    }
}
