using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Units
{
    public class EfCoreUnitRepository : EfCoreCommonRepository<Unit>, IUnitRepository
    {
        public EfCoreUnitRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
