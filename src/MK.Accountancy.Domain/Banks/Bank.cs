using MK.Accountancy.SpecialCodes;

namespace MK.Accountancy.Banks
{
    public class Bank : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public SpecialCode SpecialCodeOne { get; set; }
        public SpecialCode SpecialCodeTwo { get; set; }
    }
}
