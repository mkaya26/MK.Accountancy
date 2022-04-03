using MK.Accountancy.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.BankAccounts
{
    public class SelectBankAccountDto : EntityDto<Guid>,IActive,ISpecialCode
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public BankAccountType BankAccountType { get; set; }
        public string BankAccountTypeName { get; set; }
        public string AccountId { get; set; }
        public string Iban { get; set; }
        public Guid BankId { get; set; }
        public string BankName { get; set; }
        public Guid BankDepartmentId { get; set; }
        public string BankDepartmentName { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public string SpecialCodeOneName { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string SpecialCodeTwoName { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
