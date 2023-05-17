using MK.Accountancy.Abstract;
using MK.Accountancy.Invoices;
using MK.Accountancy.Stocks;

namespace MK.Accountancy.Stores
{
    public interface IStoreMoventAppService : ICrudAppService<SelectInvoiceDetailDto, ListStockMoventDto, StoreMoventListParameterDto, InvoiceDetailDto, InvoiceDetailDto, InvoiceNumberParameterDto>
    {

    }
}
