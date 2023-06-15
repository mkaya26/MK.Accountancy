using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Reports
{
    public class EfCoreIncomeExpenseBalanceRepository : EfCoreCommonNoKeyRepository<IncomeExpenseBalance>, IIncomeExpenseBalanceRepository
    {
        public EfCoreIncomeExpenseBalanceRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
