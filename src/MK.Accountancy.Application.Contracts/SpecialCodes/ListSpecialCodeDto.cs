using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.SpecialCodes
{
    public class ListSpecialCodeDto : EntityDto<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
