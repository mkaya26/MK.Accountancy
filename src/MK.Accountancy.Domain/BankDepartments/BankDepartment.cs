namespace MK.Accountancy.BankDepartments
{
    public class BankDepartment : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? SpecialCodeOne { get; set; }
        public Guid? SpecialCodeTwo { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
