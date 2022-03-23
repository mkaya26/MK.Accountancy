namespace MK.Accountancy.Parameters
{
    public class OrganizationParameter : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public Guid? StoryId { get; set; }
    }
}
