namespace MK.Accountancy.BankAccounts
{
    public class BankAccount : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public BankAccountType BankAccountType { get; set; }
        public string AccountId { get; set; }
        public string Iban { get; set; }
        public Guid BankDepartmentId { get; set; }
        public Guid? SpecialCodeOne { get; set; }
        public Guid? SpecialCodeTwo { get; set; }
        public Guid DepartmentId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
