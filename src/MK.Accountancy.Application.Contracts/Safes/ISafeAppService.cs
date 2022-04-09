using MK.Accountancy.Abstract;

namespace MK.Accountancy.Safes
{
    public interface ISafeAppService : ICrudAppService<SelectSafeDto, ListSafeDto, SafeListParameterDto, CreateSafeDto, UpdateSafeDto, SafeCodeParameterDto>
    {
    }
}
