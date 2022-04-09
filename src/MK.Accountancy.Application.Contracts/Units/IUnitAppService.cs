using MK.Accountancy.Abstract;
using MK.Accountancy.CommonDtos;

namespace MK.Accountancy.Units
{
    public interface IUnitAppService : ICrudAppService<SelectUnitDto, ListUnitDto, UnitListParameterDto, CreateUnitDto, UpdateUnitDto, CodeParameterDto>
    {
    }
}
