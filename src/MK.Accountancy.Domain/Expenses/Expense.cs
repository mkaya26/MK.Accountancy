namespace MK.Accountancy.Expenses
{
    public class Expense : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int TaxRate { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid UnitId { get; set; }
        public Guid? SpecialCodeOne { get; set; }
        public Guid? SpecialCodeTwo { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
