using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Parameters
{
    public class CreateOrganizationParameterDto : IEntityDto
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public Guid? StoryId { get; set; }
    }
}
