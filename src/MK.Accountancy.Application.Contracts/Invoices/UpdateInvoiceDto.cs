using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Invoices
{
    public class UpdateInvoiceDto : IEntityDto
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid CurrentId { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? DiscountTotal { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? Netamount { get; set; }
        public int MovementNumber { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public IList<InvoiceDetailDto> InvoiceDetails { get; set; }
    }
}
