using MK.Accountancy.BankDepartments;
using MK.Accountancy.Departments;
using MK.Accountancy.Receipts;
using MK.Accountancy.SpecialCodes;

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
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public Guid DepartmentId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public BankDepartment BankDepartment { get; set; }
        public SpecialCode SpecialCodeOne { get; set; }
        public SpecialCode SpecialCodeTwo { get; set; }
        public Department Department { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
        public ICollection<ReceiptDetail> ReceiptDetails { get; set; }
    }
}
