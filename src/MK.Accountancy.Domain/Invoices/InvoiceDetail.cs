﻿namespace MK.Accountancy.Invoices
{
    public class InvoiceDetail : FullAuditedEntity<Guid>
    {
        public Guid InvoiceId { get; set; }
        public InvoiceDetailType InvoiceDetailType { get; set; }
        public Guid? StockId { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? ExpenseId { get; set; }
        public Guid? StoryId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public int TaxRate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal NetTotal { get; set; }
        public string Description { get; set; }
    }
}
