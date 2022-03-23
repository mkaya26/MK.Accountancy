namespace MK.Accountancy.Invoices
{
    public class Invoice : FullAuditedAggregateRoot<Guid>
    {
        public InvoiceType InvoiceType { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Netamount { get; set; }
        public int ItemNumber { get; set; }
        public Guid CurrentId { get; set; }
        public Guid? SpecialCodeOne { get; set; }
        public Guid? SpecialCodeTwo { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
