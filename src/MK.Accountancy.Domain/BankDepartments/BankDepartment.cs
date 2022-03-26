using MK.Accountancy.BankAccounts;
using MK.Accountancy.Banks;
using MK.Accountancy.Receipts;
using MK.Accountancy.SpecialCodes;

namespace MK.Accountancy.BankDepartments
{
    public class BankDepartment : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid BankId { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public ICollection<BankAccount> BankAccounts { get; set; }
        public Bank Bank { get; set; }
        public SpecialCode SpecialCodeOne { get; set; }
        public SpecialCode SpecialCodeTwo { get; set; }
        public ICollection<ReceiptDetail> ChequeReceiptDetails { get; set; }
    }
}
