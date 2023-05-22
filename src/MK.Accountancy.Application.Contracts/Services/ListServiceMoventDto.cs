using MK.Accountancy.Invoices;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Services
{
    public class ListServiceMoventDto : EntityDto<Guid>
    {
        public Guid? ServiceId { get; set; }
        public Guid? InvoiceId { get; set; }
        public DateTime? MoventDate { get; set; }
        public string DocumentNo { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string DocumentType { get; set; }
        public InvoiceDetailType InvoiceDetailType { get; set; }
        public string InvoiceDetailTypeName { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public string UnitName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
