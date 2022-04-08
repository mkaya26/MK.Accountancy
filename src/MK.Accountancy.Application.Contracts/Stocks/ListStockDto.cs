using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Stocks
{
    public class ListStockDto : EntityDto<Guid>
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int TaxRate { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitName { get; set; }
        public string SpecialCodeOneName { get; set; }
        public string SpecialCodeTwoName { get; set; }
        public decimal InStock { get; set; }
        public decimal OutStock { get; set; }
        public decimal Balance => InStock - OutStock;
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
