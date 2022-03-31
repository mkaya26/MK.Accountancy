using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Invoices
{
    public class EfCoreInvoiceRepository : EfCoreCommonRepository<Invoice>, IInvoiceRepository
    {
        public EfCoreInvoiceRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
