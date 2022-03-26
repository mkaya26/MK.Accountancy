using MK.Accountancy.Departments;
using MK.Accountancy.Invoices;
using MK.Accountancy.Parameters;
using MK.Accountancy.SpecialCodes;

namespace MK.Accountancy.Stores
{
    public class Store : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public Department Department { get; set; }
        public SpecialCode SpecialCodeOne { get; set; }
        public SpecialCode SpecialCodeTwo { get; set; }
        public ICollection<OrganizationParameter> OrganizationParameters { get; set; } 
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
