using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.SpecialCodes;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class SpecialCodeService : BaseService<ListSpecialCodeDto,SelectSpecialCodeDto>,IScopedDependency
    {
    }
}
