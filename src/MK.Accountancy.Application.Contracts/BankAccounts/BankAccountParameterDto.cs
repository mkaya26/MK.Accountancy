using MK.Accountancy.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.BankAccounts
{
    public class BankAccountParameterDto : IEntityDto,IActive
    {
        public Guid DepartmentId { get; set; }
        public bool Active { get; set; }
    }
}
