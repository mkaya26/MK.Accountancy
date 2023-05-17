using MK.Accountancy.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Stores
{
    public class StoreMoventListParameterDto : PagedResultRequestDto,IActive,IEntityDto
    {
        public Guid StoreId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public bool Active { get; set; }
    }
}
