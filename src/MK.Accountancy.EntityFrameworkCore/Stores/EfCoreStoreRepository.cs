using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Stores
{
    public class EfCoreStoreRepository : EfCoreCommonRepository<Store>, IStoreRepository
    {
        public EfCoreStoreRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
