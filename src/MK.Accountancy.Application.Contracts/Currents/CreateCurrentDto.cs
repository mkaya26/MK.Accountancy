using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Currents
{
    public class CreateCurrentDto : IEntityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string TaxDepartment { get; set; }
        public string TaxNumber { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
