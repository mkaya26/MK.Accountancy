using MK.Accountancy.Invoices;
using MK.Accountancy.Receipts;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Currents
{
    public class ListCurrentMoventDto : EntityDto<Guid>
    {
        public Guid CurrentId { get; set; }
        public Guid? InvoiceId { get; set; }
        public Guid? ReceiptId { get; set; }
        public DateTime MoventDate { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public ReceiptType ReceiptType { get; set; }
        public string MoventType { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
