using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MK.Accountancy.Data;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.EntityFrameworkCore;

public class EntityFrameworkCoreAccountancyDbSchemaMigrator
    : IAccountancyDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAccountancyDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AccountancyDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AccountancyDbContext>()
            .Database
            .MigrateAsync();
    }
}
