using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Parameters
{
    public class UpdateOrganizationParameterDto : IEntityDto
    {
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public Guid? StoryId { get; set; }
    }
}
