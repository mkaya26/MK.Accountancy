using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Receipts
{
    public class EfCoreReceiptDetailRepository : EfCoreCommonRepository<ReceiptDetail>, IReceiptDetailRepository
    {
        public EfCoreReceiptDetailRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
