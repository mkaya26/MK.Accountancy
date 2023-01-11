using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Safes;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class SafeService : BaseService<ListSafeDto,SelectSafeDto>,IScopedDependency
    {
    }
}
