using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Invoices
{
    public class EfCoreInvoiceDetailRepository : EfCoreCommonRepository<InvoiceDetail>, IInvoiceDetailRepository
    {
        public EfCoreInvoiceDetailRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
