using MK.Accountancy.Departments;
using MK.Accountancy.Receipts;
using MK.Accountancy.SpecialCodes;

namespace MK.Accountancy.Safes
{
    public class Safe : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public Guid DepartmentId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public SpecialCode SpecialCodeOne { get; set; }
        public SpecialCode SpecialCodeTwo { get; set; }
        public Department Department { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
        public ICollection<ReceiptDetail> ReceiptDetails { get; set; }
    }
}
