using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.BankAccounts
{
    public class UpdateBankAccountDto : IEntityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public BankAccountType BankAccountType { get; set; }
        public string AccountId { get; set; }
        public string Iban { get; set; }
        public Guid? BankDepartmentId { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
