namespace MK.Accountancy.Receipts
{
    public class Receipt : FullAuditedAggregateRoot<Receipt>
    {
        public ReceiptType ReceiptType { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime ReceiptDate { get; set; }
        public Guid? CurrentId { get; set; }
        public Guid? SafeId { get; set; }
        public Guid? BankAccountId { get; set; }
        public int MovementNumber { get; set; }
        public decimal CheckTotal { get; set; }
        public decimal BillTotal { get; set; }
        public decimal PostTotal { get; set; }
        public decimal CashTotal { get; set; }
        public decimal BankTotal { get; set; }
        public Guid? SpecialCodeOne { get; set; }
        public Guid? SpecialCodeTwo { get; set; }
        public Guid DepartmentId { get; set; }2
        public Guid TermId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
