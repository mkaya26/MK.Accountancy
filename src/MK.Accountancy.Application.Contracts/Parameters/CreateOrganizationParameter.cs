using System;

namespace MK.Accountancy.Parameters
{
    public class CreateOrganizationParameter
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public Guid? StoryId { get; set; }
    }
}
