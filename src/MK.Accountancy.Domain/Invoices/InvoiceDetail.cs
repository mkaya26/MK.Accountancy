using MK.Accountancy.Expenses;
using MK.Accountancy.Services;
using MK.Accountancy.Stocks;
using MK.Accountancy.Stores;

namespace MK.Accountancy.Invoices
{
    public class InvoiceDetail : FullAuditedEntity<Guid>
    {
        public Guid InvoiceId { get; set; }
        public InvoiceDetailType InvoiceDetailType { get; set; }
        public Guid? StockId { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? ExpenseId { get; set; }
        public Guid? StoreId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public int TaxRate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal NetTotal { get; set; }
        public string Description { get; set; }
        public Invoice Invoice { get; set; }
        public Stock Stock { get; set; }
        public Service Service { get; set; }
        public Expense Expense { get; set; }
        public Store Store { get; set; }
    }
}
