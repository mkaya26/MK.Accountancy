using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Currents;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class CurrentService : BaseService<ListCurrentDto,SelectCurrentDto>,IScopedDependency
    {
    }
}
