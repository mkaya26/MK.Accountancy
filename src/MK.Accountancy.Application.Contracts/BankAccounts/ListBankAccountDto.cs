using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.BankAccounts
{
    public class ListBankAccountDto : EntityDto<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public BankAccountType BankAccountType { get; set; }
        public string BankAccountTypeName { get; set; }
        public string AccountId { get; set; }
        public string Iban { get; set; }
        public string BankName { get; set; }
        public string BankDepartmentName { get; set; }
        public string SpecialCodeOneName { get; set; }
        public string SpecialCodeTwoName { get; set; }
        public decimal Debt { get; set; }
        public decimal Receivable { get; set; }
        public decimal DebtBalance => Debt - Receivable > 0 ? Debt - Receivable : 0;
        public decimal BalanceReceivable => Receivable - Debt > 0 ? Receivable - Debt : 0;
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
