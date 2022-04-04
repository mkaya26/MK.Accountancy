using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Services
{
    public class ListServiceDto : EntityDto<Guid>
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int TaxRate { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitName { get; set; }
        public string SpecialCodeOneName { get; set; }
        public string SpecialCodeTwoName { get; set; }
        public string Description { get; set; }
        public decimal InService { get; set; }
        public decimal OutService { get; set; }
        public bool Active { get; set; }
    }
}
