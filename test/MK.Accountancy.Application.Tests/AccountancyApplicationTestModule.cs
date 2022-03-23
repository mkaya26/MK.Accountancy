using Volo.Abp.Modularity;

namespace MK.Accountancy;

[DependsOn(
    typeof(AccountancyApplicationModule),
    typeof(AccountancyDomainTestModule)
    )]
public class AccountancyApplicationTestModule : AbpModule
{

}
