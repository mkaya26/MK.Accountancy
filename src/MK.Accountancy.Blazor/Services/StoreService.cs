using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Stores;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class StoreService : BaseService<ListStoreDto,SelectStoreDto>,IScopedDependency
    {
    }
}
