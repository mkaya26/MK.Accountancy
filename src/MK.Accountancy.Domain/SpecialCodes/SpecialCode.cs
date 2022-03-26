using MK.Accountancy.BankAccounts;
using MK.Accountancy.BankDepartments;
using MK.Accountancy.Banks;
using MK.Accountancy.Currents;
using MK.Accountancy.Expenses;
using MK.Accountancy.Invoices;
using MK.Accountancy.Receipts;
using MK.Accountancy.Safes;
using MK.Accountancy.Services;
using MK.Accountancy.Stocks;
using MK.Accountancy.Stores;
using MK.Accountancy.Units;

namespace MK.Accountancy.SpecialCodes
{
    public class SpecialCode : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public SpecialCodeType SpecialCodeType { get; set; }
        public CardType CardType { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public ICollection<BankAccount> SpecialCodeOneBankAccounts { get; set; }
        public ICollection<BankAccount> SpecialCodeTwoBankAccounts { get; set; }
        public ICollection<Bank> SpecialCodeOneBanks { get; set; }
        public ICollection<Bank> SpecialCodeTwoBanks { get; set; }
        public ICollection<BankDepartment> SpecialCodeOneBankDepartments { get; set; }
        public ICollection<BankDepartment> SpecialCodeTwoBankDepartments { get; set; }
        public ICollection<Unit> SpecialCodeOneUnits { get; set; }
        public ICollection<Unit> SpecialCodeTwoUnits { get; set; }
        public ICollection<Current> SpecialCodeOneCurrents { get; set; }
        public ICollection<Current> SpecialCodeTwoCurrents { get; set; }
        public ICollection<Store> SpecialCodeOneStores { get; set; }
        public ICollection<Store> SpecialCodeTwoStores { get; set; }
        public ICollection<Invoice> SpecialCodeOneInvoices { get; set; }
        public ICollection<Invoice> SpecialCodeTwoInvoices { get; set; }
        public ICollection<Service> SpecialCodeOneServices { get; set; }
        public ICollection<Service> SpecialCodeTwoServices { get; set; }
        public ICollection<Safe> SpecialCodeOneSafes { get; set; }
        public ICollection<Safe> SpecialCodeTwoSafes { get; set; }
        public ICollection<Receipt> SpecialCodeOneReceipts { get; set; }
        public ICollection<Receipt> SpecialCodeTwoReceipts { get; set; }
        public ICollection<Stock> SpecialCodeOneStocks { get; set; }
        public ICollection<Stock> SpecialCodeTwoStocks { get; set; }
        public ICollection<Expense> SpecialCodeOneExpenses { get; set; }
        public ICollection<Expense> SpecialCodeTwoExpenses { get; set; }
    }
}
