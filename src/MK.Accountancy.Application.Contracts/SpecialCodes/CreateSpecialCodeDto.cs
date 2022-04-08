using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.SpecialCodes
{
    public class CreateSpecialCodeDto : IEntityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public SpecialCodeType SpecialCodeType { get; set; }
        public CardType CardType { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
