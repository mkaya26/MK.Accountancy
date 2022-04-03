using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Terms
{
    public class CreateTermDto : IEntityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
