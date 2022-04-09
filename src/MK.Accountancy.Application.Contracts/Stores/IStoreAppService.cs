using MK.Accountancy.Abstract;

namespace MK.Accountancy.Stores
{
    public interface IStoreAppService : ICrudAppService<SelectStoreDto, ListStoreDto, StoreListParameterDto, CreateStoreDto, UpdateStoreDto, StoreCodeParameterDto>
    {
    }
}
