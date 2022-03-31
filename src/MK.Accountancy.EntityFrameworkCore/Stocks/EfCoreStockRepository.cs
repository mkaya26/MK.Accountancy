using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Stocks
{
    public class EfCoreStockRepository : EfCoreCommonRepository<Stock>, IStockRepository
    {
        public EfCoreStockRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
