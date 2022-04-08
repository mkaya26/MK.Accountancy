using MK.Accountancy.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Expenses
{
    public class ExpenseListParameterDto : PagedResultRequestDto,IEntityDto,IActive
    {
        public bool Active { get; set; }
    }
}
