using MK.Accountancy.Invoices;
using MK.Accountancy.Parameters;
using MK.Accountancy.Receipts;

namespace MK.Accountancy.Terms
{
    public class Term : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
        public ICollection<OrganizationParameter> OrganizationParameters { get; set; }
    }
}
