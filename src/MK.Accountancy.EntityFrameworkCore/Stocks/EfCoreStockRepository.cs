using Microsoft.EntityFrameworkCore;
using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Stocks
{
    public class EfCoreStockRepository : EfCoreCommonRepository<Stock>, IStockRepository
    {
        public EfCoreStockRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Stock>> WithDetailsAsync()
        {
            return (await GetQueryableAsync())
                .Include(i => i.Unit)
                .Include(i => i.SpecialCodeOne)
                .Include(i => i.SpecialCodeTwo)
                .Include(i => i.InvoiceDetails).ThenInclude(i => i.Invoice);
        }
    }
}
