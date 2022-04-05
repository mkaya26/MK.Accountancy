using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Receipts
{
    public class ReceiptDetailReportDto : EntityDto<Guid>
    {
        public string PaymentTypeName { get; set; }
        public string TrackingNumber { get; set; }
        public string ChequeBankName { get; set; }
        public string ChequeBankDepartmentName { get; set; }
        public string ChequeAccountNumber { get; set; }
        public string DocumentNo { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string PrincipalDebtor { get; set; }
        public string Endorser { get; set; }
        public string SafeName { get; set; }
        public string BankAccountName { get; set; }
        public decimal Price { get; set; }
        public string DocumentStatuName { get; set; }
        public bool MyDocument { get; set; }
        public string Description { get; set; }
    }
}
