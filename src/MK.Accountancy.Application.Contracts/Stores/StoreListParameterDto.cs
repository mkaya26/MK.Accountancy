using MK.Accountancy.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Stores
{
    public class StoreListParameterDto : PagedResultRequestDto,IEntityDto,IActive
    {
        public Guid DepartmentId { get; set; }
        public bool Active { get; set; }
    }
}
