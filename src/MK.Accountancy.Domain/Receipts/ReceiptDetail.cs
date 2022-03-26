using MK.Accountancy.BankAccounts;
using MK.Accountancy.BankDepartments;
using MK.Accountancy.Banks;
using MK.Accountancy.Safes;

namespace MK.Accountancy.Receipts
{
    public class ReceiptDetail : FullAuditedEntity<Guid>
    {
        public Guid ReceiptId { get; set; }
        public PaymentType PaymentType { get; set; }
        public string TrackingNumber { get; set; }
        public Guid? ChequeBankId { get; set; }
        public Guid? ChequeBankDepartmentId { get; set; }
        public string ChequeAccountNumber { get; set; }
        public string DocumentNo { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string PrincipalDebtor { get; set; }
        public string Endorser { get; set; }
        public Guid? SafeId { get; set; }
        public Guid? BankAccountId { get; set; }
        public decimal Price { get; set; }
        public DocumentStatu DocumentStatu { get; set; }
        public bool MyDocument { get; set; }
        public string Description { get; set; }
        public Receipt Receipt { get; set; }
        public Bank ChequeBank { get; set; }
        public BankDepartment ChequeBankDepartment { get; set; }
        public Safe Safe { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
