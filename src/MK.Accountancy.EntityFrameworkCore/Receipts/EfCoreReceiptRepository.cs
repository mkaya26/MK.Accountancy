using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Receipts
{
    public class EfCoreReceiptRepository : EfCoreCommonRepository<Receipt>, IReceiptRepository
    {
        public EfCoreReceiptRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
