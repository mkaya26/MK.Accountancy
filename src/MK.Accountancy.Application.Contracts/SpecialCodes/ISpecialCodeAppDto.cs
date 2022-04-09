using MK.Accountancy.Abstract;

namespace MK.Accountancy.SpecialCodes
{
    public interface ISpecialCodeAppDto : ICrudAppService<SelectSpecialCodeDto, ListSpecialCodeDto, SpecialCodeListParameterDto, CreateSpecialCodeDto, UpdateSpecialCodeDto, SpecialCodeParameterDto>
    {
    }
}
