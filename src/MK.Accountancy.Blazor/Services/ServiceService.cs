using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Services;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class ServiceService : BaseService<ListServiceDto,SelectServiceDto>,IScopedDependency
    {
    }
}
