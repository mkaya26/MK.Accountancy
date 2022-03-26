using MK.Accountancy.SpecialCodes;

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
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public SpecialCode SpecialCodeOne { get; set; }
        public SpecialCode SpecialCodeTwo { get; set; }
        public ICollection<Current> Currents { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
    }
}
