using MK.Accountancy.Banks;
using MK.Accountancy.Blazor.Services.Base;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class BankService : BaseService<BankListDto,SelectBankDto>,IScopedDependency
    {
    }
}
