using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.CommonDtos
{
    public class CodeParameterDto : IEntityDto,IActive
    {
        public bool Active { get; set; }
    }
}
