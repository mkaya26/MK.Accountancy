using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Expenses
{
    public class ListExpenseDto : EntityDto<Guid>
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int TaxRate { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitName { get; set; }
        public string SpecialCodeOneName { get; set; }
        public string SpecialCodeTwoName { get; set; }
        public decimal AmountInput { get; set; }
        public decimal OutputAmount { get; set; }
        //public decimal TheRemainingAmount => AmountInput - OutputAmount;
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
