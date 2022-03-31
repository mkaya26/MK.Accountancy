using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Expenses
{
    public class EfCoreExpenseRepository : EfCoreCommonRepository<Expense>, IExpenseRepository
    {
        public EfCoreExpenseRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
