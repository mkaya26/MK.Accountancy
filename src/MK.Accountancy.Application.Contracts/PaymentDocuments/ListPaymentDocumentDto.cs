using MK.Accountancy.Receipts;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.PaymentDocuments
{
    public class ListPaymentDocumentDto : EntityDto<Guid>
    {
        public Guid ReceiptId { get; set; }
        public PaymentType PaymentType { get; set; }
        public string PaymentTypeName { get; set; }
        public string TrackingNumber { get; set; }
        public Guid? ChequeBankId { get; set; }
        public string ChequeBankName { get; set; }
        public Guid? ChequeBankDepartmentId { get; set; }
        public string ChequeBankDepartmentName { get; set; }
        public string ChequeAccountNumber { get; set; }
        public string DocumentNo { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string PrincipalDebtor { get; set; }
        public string Endorser { get; set; }
        public Guid? SafeId { get; set; }
        public Guid? BankAccountId { get; set; }
        public string BankAccountName { get; set; }
        public decimal Price { get; set; }
        public DocumentStatu DocumentStatu { get; set; }
        public string DocumentStatuName { get; set; }
        public bool MyDocument { get; set; }
        public string Description { get; set; }
    }
}
