﻿using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Units
{
    public class ListUnitDto : EntityDto<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SpecialCodeOneName { get; set; }
        public string SpecialCodeTwoName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
