using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Banks
{
    public class EfCoreBankRepository : EfCoreCommonRepository<Bank>, IBankRepository
    {
        public EfCoreBankRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
