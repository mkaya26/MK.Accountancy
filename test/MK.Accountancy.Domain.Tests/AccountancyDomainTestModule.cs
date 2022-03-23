using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MK.Accountancy;

[DependsOn(
    typeof(AccountancyEntityFrameworkCoreTestModule)
    )]
public class AccountancyDomainTestModule : AbpModule
{

}
