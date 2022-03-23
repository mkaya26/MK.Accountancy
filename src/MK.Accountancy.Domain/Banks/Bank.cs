namespace MK.Accountancy.Banks
{
    public class Bank : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? SpecialCodeOne { get; set; }
        public Guid? SpecialCodeTwo { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
