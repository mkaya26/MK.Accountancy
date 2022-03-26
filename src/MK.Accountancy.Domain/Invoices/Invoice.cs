using MK.Accountancy.Currents;
using MK.Accountancy.Departments;
using MK.Accountancy.SpecialCodes;
using MK.Accountancy.Terms;

namespace MK.Accountancy.Invoices
{
    public class Invoice : FullAuditedAggregateRoot<Guid>
    {
        public InvoiceType InvoiceType { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Netamount { get; set; }
        public int MovementNumber { get; set; }
        public Guid CurrentId { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public Current Current { get; set; }
        public SpecialCode SpecialCodeOne { get; set; }
        public SpecialCode SpecialCodeTwo { get; set; }
        public Department Department { get; set; }
        public Term Term { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
