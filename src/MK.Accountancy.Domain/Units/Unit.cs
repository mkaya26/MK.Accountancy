using MK.Accountancy.Expenses;
using MK.Accountancy.Services;
using MK.Accountancy.SpecialCodes;
using MK.Accountancy.Stocks;

namespace MK.Accountancy.Units
{
    public class Unit : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public SpecialCode SpecialCodeOne { get; set; }
        public SpecialCode SpecialCodeTwo { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Stock> Stocks { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
