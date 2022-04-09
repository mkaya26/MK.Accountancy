using MK.Accountancy.Abstract;
using MK.Accountancy.CommonDtos;

namespace MK.Accountancy.Terms
{
    public interface ITermAppService : ICrudAppService<SelectTermDto, ListTermDto, TermListParameterDto, CreateTermDto, UpdateTermDto, CodeParameterDto>
    {
    }
}
