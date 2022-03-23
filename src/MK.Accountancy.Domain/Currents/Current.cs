namespace MK.Accountancy.Currents
{
    public class Current : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string TaxDepartment { get; set; }
        public string TaxNumber { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public Guid? SpecialCodeOne { get; set; }
        public Guid? SpecialCodeTwo { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
