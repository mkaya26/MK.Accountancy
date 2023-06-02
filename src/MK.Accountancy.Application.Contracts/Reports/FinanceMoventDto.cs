using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Reports
{
    public class FinanceMoventDto : IEntityDto
    {
        public DateTime Date { get; set; }
        public string ReceiptNo { get; set; }
        public decimal Debt { get; set; }
        public decimal Receivable { get; set; }
        public string Description { get; set; }
    }
}
