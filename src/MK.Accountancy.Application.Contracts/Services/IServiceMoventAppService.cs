using MK.Accountancy.Abstract;
using MK.Accountancy.Invoices;

namespace MK.Accountancy.Services
{
    public interface IServiceMoventAppService : ICrudAppService<SelectInvoiceDetailDto, ListServiceMoventDto, ServiceMoventListParameterDto, InvoiceDetailDto, InvoiceDetailDto, InvoiceNumberParameterDto>
    {
    }
}
