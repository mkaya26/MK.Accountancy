using MK.Accountancy.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Banks
{
    public class BankListParameterDto : PagedResultRequestDto,IEntityDto,IActive
    {
        public bool Active { get; set; }
    }
}
