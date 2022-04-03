using MK.Accountancy.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Currents
{
    public class CurrentMoventListParameterDto : PagedResultRequestDto,IEntityDto,IActive
    {
        public Guid CurrentId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public bool Active { get; set; }
    }
}
