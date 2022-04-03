using MK.Accountancy.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Units
{
    public class UnitListParameterDto : PagedResultRequestDto,IEntityDto,IActive
    {
        public bool Active { get; set; }
    }
}
