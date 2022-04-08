using MK.Accountancy.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.SpecialCodes
{
    public class SpecialCodeParameterDto : PagedResultRequestDto,IEntityDto,IActive
    {
        public SpecialCodeType SpecialCodeType { get; set; }
        public CardType CardType { get; set; }
        public bool Active { get; set; }
    }
}
