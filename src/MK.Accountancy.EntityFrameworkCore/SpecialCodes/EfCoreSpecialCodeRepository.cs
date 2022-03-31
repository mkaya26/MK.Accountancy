using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.SpecialCodes
{
    public class EfCoreSpecialCodeRepository : EfCoreCommonRepository<SpecialCode>, ISpecialCodeRepository
    {
        public EfCoreSpecialCodeRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
