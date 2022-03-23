using System.Threading.Tasks;

namespace MK.Accountancy.Data;

public interface IAccountancyDbSchemaMigrator
{
    Task MigrateAsync();
}
