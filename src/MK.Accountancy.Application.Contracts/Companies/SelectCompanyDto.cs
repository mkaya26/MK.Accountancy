using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Companies
{
    public class SelectCompanyDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string WebAddress { get; set; }
        public string Bank { get; set; }
        public string BankDepartment { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankIbanNumber { get; set; }
        public string LogoUrl { get; set; }
    }
}
