using MK.Accountancy.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Departments
{
    public class DepartmentListParameterDto : PagedResultRequestDto, IEntityDto, IActive
    {
        public bool Active { get; set; }
    }
}
