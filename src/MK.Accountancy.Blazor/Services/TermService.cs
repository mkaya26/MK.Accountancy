using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Terms;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class TermService : BaseService<ListTermDto,SelectTermDto>,IScopedDependency
    {
    }
}
