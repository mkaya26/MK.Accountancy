using MK.Accountancy.CommonDtos;
using MK.Accountancy.Invoices;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Stocks
{
    public class StockMoventListParameterDto : PagedResultRequestDto, IEntityDto, IActive
    {
        public InvoiceDetailType? InvoiceDetailType { get; set; }
        public Guid EntityId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public bool Active {get; set;}
    }
}
