using MK.Accountancy.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Currents
{
    public class CurrentListParameterDto : PagedResultRequestDto, IEntityDto, IActive
    {
        public bool Active { get; set; }
    }
}
