using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Safes
{
    public class EfCoreSafeRepository : EfCoreCommonRepository<Safe>, ISafeRepository
    {
        public EfCoreSafeRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
