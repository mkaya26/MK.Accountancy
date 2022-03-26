using MK.Accountancy.BankAccounts;
using MK.Accountancy.Currents;
using MK.Accountancy.Departments;
using MK.Accountancy.Safes;
using MK.Accountancy.SpecialCodes;
using MK.Accountancy.Terms;

namespace MK.Accountancy.Receipts
{
    public class Receipt : FullAuditedAggregateRoot<Receipt>
    {
        public ReceiptType ReceiptType { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime ReceiptDate { get; set; }
        public Guid? CurrentId { get; set; }
        public Guid? SafeId { get; set; }
        public Guid? BankAccountId { get; set; }
        public int MovementNumber { get; set; }
        public decimal ChequeTotal { get; set; }
        public decimal BillTotal { get; set; }
        public decimal PostTotal { get; set; }
        public decimal CashTotal { get; set; }
        public decimal BankTotal { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public Current Current { get; set; }
        public Safe Safe { get; set; }
        public BankAccount BankAccount { get; set; }
        public SpecialCode SpecialCodeOne { get; set; }
        public SpecialCode SpecialCodeTwo { get; set; }
        public Department Department { get; set; }
        public Term Term { get; set; }
        public ICollection<ReceiptDetail> ReceiptDetails { get; set; }
    }
}
