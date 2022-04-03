﻿using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.BankDepartments
{
    public class UpdateBankDepartmentDto : IEntityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
