using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Safes
{
    public class CreateSafeDto : IEntityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public Guid? DepartmentId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
