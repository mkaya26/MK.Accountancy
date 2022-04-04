using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Invoices
{
    public class InvoiceDetailReportDto : EntityDto<Guid>
    {
        public string InvoiceDetailTypeName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string StockCode { get; set; }
        public string StockName { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string ExpenceCode { get; set; }
        public string ExpenceName { get; set; }
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
    }
}
