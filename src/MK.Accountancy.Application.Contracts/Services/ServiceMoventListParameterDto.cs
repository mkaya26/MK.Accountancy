using MK.Accountancy.CommonDtos;
using MK.Accountancy.Invoices;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Services
{
    public class ServiceMoventListParameterDto : PagedResultRequestDto, IActive, IEntityDto
    {
        public Guid ServiceId { get; set; }
        public InvoiceDetailType InvoiceDetailType { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public bool Active { get; set; }
    }
}