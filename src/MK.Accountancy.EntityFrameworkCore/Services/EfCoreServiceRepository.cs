using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Services
{
    public class EfCoreServiceRepository : EfCoreCommonRepository<Service>, IServiceRepository
    {
        public EfCoreServiceRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
