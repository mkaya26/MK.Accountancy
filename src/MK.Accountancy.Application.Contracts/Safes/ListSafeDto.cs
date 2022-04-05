using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Safes
{
    public class ListSafeDto : EntityDto<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SpecialCodeOneName { get; set; }
        public string SpecialCodeTwoName { get; set; }
        public decimal Debt { get; set; }
        public decimal Receivable { get; set; }
        public decimal DebtBalance => Debt - Receivable > 0 ? Debt - Receivable : 0;
        public decimal BalanceReceivable => Receivable - Debt > 0 ? Receivable - Debt : 0;
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
