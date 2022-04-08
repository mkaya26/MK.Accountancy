using MK.Accountancy.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Stocks
{
    public class StockListParameterDto : PagedResultRequestDto, IEntityDto, IActive
    {
        public bool Active { get; set; }
    }
}
