using MK.Accountancy.BankAccounts;
using MK.Accountancy.Invoices;
using MK.Accountancy.Parameters;
using MK.Accountancy.Receipts;
using MK.Accountancy.Safes;
using MK.Accountancy.Stores;

namespace MK.Accountancy.Departments
{
    public class Department : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public ICollection<BankAccount> BankAccounts { get; set; }
        public ICollection<Store> Stores { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
        public ICollection<OrganizationParameter> OrganizationParameters { get; set; }
        public ICollection<Safe> Safes { get; set; }
    }
}
