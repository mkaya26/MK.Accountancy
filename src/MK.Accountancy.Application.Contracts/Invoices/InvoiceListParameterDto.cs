using MK.Accountancy.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Invoices
{
    public class InvoiceListParameterDto : PagedResultRequestDto,IEntityDto,IActive
    {
        public InvoiceType InvoiceType { get; set; }
        public Guid CurrentId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public bool Active { get; set; }
    }
}
