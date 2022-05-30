using MK.Accountancy.Abstract;

namespace MK.Accountancy.SpecialCodes
{
    public interface ISpecialCodeAppService : ICrudAppService<SelectSpecialCodeDto, ListSpecialCodeDto, SpecialCodeListParameterDto, CreateSpecialCodeDto, UpdateSpecialCodeDto, SpecialCodeParameterDto>
    {
    }
}
