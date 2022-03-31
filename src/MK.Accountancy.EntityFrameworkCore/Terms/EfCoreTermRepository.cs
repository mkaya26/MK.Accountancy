using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Terms
{
    public class EfCoreTermRepository : EfCoreCommonRepository<Term>, ITermRepository
    {
        public EfCoreTermRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
