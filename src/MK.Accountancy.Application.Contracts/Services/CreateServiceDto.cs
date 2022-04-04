using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Services
{
    public class CreateServiceDto : IEntityDto
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int TaxRate { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid? UnitId { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
