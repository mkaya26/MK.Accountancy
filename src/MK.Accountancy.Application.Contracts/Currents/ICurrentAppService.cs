using MK.Accountancy.Abstract;
using MK.Accountancy.CommonDtos;

namespace MK.Accountancy.Currents
{
    public interface ICurrentAppService : ICrudAppService<SelectCurrentDto, ListCurrentDto, CurrentListParameterDto, CreateCurrentDto, UpdateCurrentDto, CodeParameterDto>
    {
    }
}
