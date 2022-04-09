using MK.Accountancy.Abstract;

namespace MK.Accountancy.Invoices
{
    public interface IInvoiceAppService : ICrudAppService<SelectInvoiceDto, ListInvoiceDto, InvoiceListParameterDto, CreateInvoiceDto, UpdateInvoiceDto, InvoiceNumberParameterDto>
    {
    }
}
