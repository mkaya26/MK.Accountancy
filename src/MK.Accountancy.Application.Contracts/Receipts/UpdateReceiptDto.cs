using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Receipts
{
    public class UpdateReceiptDto : IEntityDto
    {
        public ReceiptType ReceiptType { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime? ReceiptDate { get; set; }
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
        public string Description { get; set; }
        public bool Active { get; set; }
        public IList<ReceiptDetailDto> ReceiptDetails { get; set; }
    }
}
