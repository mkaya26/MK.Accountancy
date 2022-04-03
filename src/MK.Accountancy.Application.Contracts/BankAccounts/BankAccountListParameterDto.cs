using MK.Accountancy.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.BankAccounts
{
    public class BankAccountListParameterDto : PagedResultRequestDto,IEntityDto,IActive
    {
        public BankAccountType? BankAccountType { get; set; }
        public Guid DepartmentId { get; set; }
        public bool Active { get; set; }
    }
}
