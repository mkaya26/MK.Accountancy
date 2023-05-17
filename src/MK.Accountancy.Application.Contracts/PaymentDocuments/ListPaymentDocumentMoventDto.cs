using MK.Accountancy.Receipts;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.PaymentDocuments
{
    public class ListPaymentDocumentMoventDto : EntityDto<Guid>
    {
        public string ReceiptNumber { get; set; }
        public Guid BankAccountId { get; set; }
        public Guid ReceiptId { get; set; }
        public DateTime Date { get; set; }
        public PaymentType PaymentType { get; set; }
        public string PaymentTypeName { get; set; }
        public string TrackingNumber { get; set; }
        public string DocumentNo { get; set; }
        public ReceiptType ReceiptType { get; set; }
        public string ReceiptTypeName { get; set; }
        public DocumentStatu DocumentStatu { get; set; }
        public string DocumentStatuName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
