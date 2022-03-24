using MK.Accountancy.BankAccounts;

namespace MK.Accountancy.Departments
{
    public class Department : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public ICollection<BankAccount> BankAccounts { get; set; }
    }
}
