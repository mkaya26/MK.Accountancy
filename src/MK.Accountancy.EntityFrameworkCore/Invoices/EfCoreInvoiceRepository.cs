using Microsoft.EntityFrameworkCore;
using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Invoices
{
    public class EfCoreInvoiceRepository : EfCoreCommonRepository<Invoice>, IInvoiceRepository
    {
        public EfCoreInvoiceRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Invoice>> WithDetailsAsync()
        {
            return (await GetQueryableAsync())
                .Include(i => i.Current)
                .Include(i => i.SpecialCodeOne)
                .Include(i => i.SpecialCodeTwo)
                .Include(i => i.InvoiceDetails).ThenInclude(i => i.Store)
                .Include(i => i.InvoiceDetails).ThenInclude(i => i.Stock)
                                               .ThenInclude(i => i.Unit)
                .Include(i => i.InvoiceDetails).ThenInclude(i => i.Service)
                                               .ThenInclude(i => i.Unit)
                .Include(i => i.InvoiceDetails).ThenInclude(i => i.Expense)
                                               .ThenInclude(i => i.Unit);
        }
    }
}
