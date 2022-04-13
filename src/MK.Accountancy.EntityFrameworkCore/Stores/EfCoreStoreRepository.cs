using Microsoft.EntityFrameworkCore;
using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Stores
{
    public class EfCoreStoreRepository : EfCoreCommonRepository<Store>, IStoreRepository
    {
        public EfCoreStoreRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Store>> WithDetailsAsync()
        {
            return (await GetQueryableAsync())
                         .Include(i => i.SpecialCodeOne)
                         .Include(i => i.SpecialCodeTwo)
                         .Include(i => i.InvoiceDetails).ThenInclude(i => i.Invoice);
        }
    }
}
