using MK.Accountancy.Departments;
using MK.Accountancy.Stores;
using MK.Accountancy.Terms;
using Volo.Abp.Identity;

namespace MK.Accountancy.Parameters
{
    public class OrganizationParameter : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public Guid? StoryId { get; set; }
        public IdentityUser User { get; set; }
        public Department Department { get; set; }
        public Term Term { get; set; }
        public Store Store { get; set; }
    }
}
