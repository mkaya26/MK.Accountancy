using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Invoices
{
    public class ListInvoiceDto : EntityDto<Guid>
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CurrentName { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Netamount { get; set; }
        public int MovementNumber { get; set; }
        public string SpecialCodeOneName { get; set; }
        public string SpecialCodeTwoName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
