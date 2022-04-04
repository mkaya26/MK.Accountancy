using MK.Accountancy.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Services
{
    public class ServiceListParameterDto : PagedResultRequestDto,IEntityDto,IActive
    {
        public bool Active { get; set; }
    }
}
