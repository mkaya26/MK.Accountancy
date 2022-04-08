using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Parameters
{
    public class SelectOrganizationParameterDto : EntityDto<Guid>
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Guid TermId { get; set; }
        public string TermName { get; set; }
        public Guid? StoryId { get; set; }
        public string StoryName { get; set; }
    }
}
