using MK.Accountancy.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Terms
{
    public class TermListParameterDto : PagedResultRequestDto, IEntityDto, IActive
    {
        public bool Active { get; set; }
    }
}
