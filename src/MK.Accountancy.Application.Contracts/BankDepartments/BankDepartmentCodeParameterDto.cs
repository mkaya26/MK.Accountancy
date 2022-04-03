﻿using MK.Accountancy.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.BankDepartments
{
    public class BankDepartmentCodeParameterDto : IEntityDto,IActive
    {
        public Guid BankId { get; set; }
        public bool Active { get; set; }
    }
}
