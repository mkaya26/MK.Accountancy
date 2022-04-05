using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Receipts
{
    public class ReceiptReportDto : IEntityDto
    {
        public string ReceiptNumber { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string CurrentCode { get; set; }
        public string CurrentName { get; set; }
        public string SafeName { get; set; }
        public string BankAccountName { get; set; }
        public decimal ChequeTotal { get; set; }
        public decimal BillTotal { get; set; }
        public decimal PostTotal { get; set; }
        public decimal CashTotal { get; set; }
        public decimal BankTotal { get; set; }
        public decimal GrandTotal => ChequeTotal + BillTotal + PostTotal + CashTotal + BankTotal;
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<ReceiptDetailReportDto> ReceiptDetailReports { get; set; }
    }
}
