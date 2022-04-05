using MK.Accountancy.CommonDtos;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Receipts
{
    public class SelectReceiptDto : EntityDto<Guid>,ISpecialCode
    {
        public ReceiptType ReceiptType { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime ReceiptDate { get; set; }
        public Guid? CurrentId { get; set; }
        public string CurrentCode { get; set; }
        public string CurrentName { get; set; }
        public Guid? SafeId { get; set; }
        public string SafeName { get; set; }
        public Guid? BankAccountId { get; set; }
        public string BankAccountName { get; set; }
        public int MovementNumber { get; set; }
        public decimal ChequeTotal { get; set; }
        public decimal BillTotal { get; set; }
        public decimal PostTotal { get; set; }
        public decimal CashTotal { get; set; }
        public decimal BankTotal { get; set; }
        public decimal GrandTotal => ChequeTotal + BillTotal + PostTotal + CashTotal + BankTotal;
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string SpecialCodeOneName { get; set; }
        public string SpecialCodeTwoName { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Guid TermId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<SelectReceiptDetailDto> receiptDetails { get; set; }
    }
}
