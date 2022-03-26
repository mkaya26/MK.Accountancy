using MK.Accountancy.Invoices;
using MK.Accountancy.SpecialCodes;
using MK.Accountancy.Units;

namespace MK.Accountancy.Services
{
    public class Service : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int TaxRate { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid UnitId { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public Unit Unit { get; set; }
        public SpecialCode SpecialCodeOne { get; set; }
        public SpecialCode SpecialCodeTwo { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
