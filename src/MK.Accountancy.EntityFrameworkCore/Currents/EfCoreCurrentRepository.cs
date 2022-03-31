using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Currents
{
    public class EfCoreCurrentRepository : EfCoreCommonRepository<Current>, ICurrentRepository
    {
        public EfCoreCurrentRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
