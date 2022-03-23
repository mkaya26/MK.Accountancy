using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace MK.Accountancy.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AccountancyEntityFrameworkCoreModule),
    typeof(AccountancyApplicationContractsModule)
    )]
public class AccountancyDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
