using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Data;

/* This is used if database provider does't define
 * IAccountancyDbSchemaMigrator implementation.
 */
public class NullAccountancyDbSchemaMigrator : IAccountancyDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
