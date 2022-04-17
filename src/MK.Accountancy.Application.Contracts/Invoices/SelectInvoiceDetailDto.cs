using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Invoices
{
    public class SelectInvoiceDetailDto : EntityDto<Guid>
    {
        public Guid InvoiceId { get; set; }
        public InvoiceDetailType InvoiceDetailType { get; set; }
        public string InvoiceDetailTypeName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int MoventNumber { get; set; }
        public Guid? StockId { get; set; }
        public string StockCode { get; set; }
        public string StockName { get; set; }
        public Guid? ServiceId { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public Guid? ExpenceId { get; set; }
        public string ExpenceCode { get; set; }
        public string ExpenceName { get; set; }
        public Guid? StoreId { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string UnitName { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public int? TaxRate { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TaxTotal { get; set; }
        public decimal? NetTotal { get; set; }
        public string Description { get; set; }
        //public SelectInvoiceDto InvoiceDto { get; set; }
    }
}
