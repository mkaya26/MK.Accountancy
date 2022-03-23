namespace MK.Accountancy.Safes
{
    public class Safe : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? SpecialCodeOne { get; set; }
        public Guid? SpecialCodeTwo { get; set; }
        public Guid DepartmentId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
