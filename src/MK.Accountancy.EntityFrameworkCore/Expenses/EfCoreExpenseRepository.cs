using Microsoft.EntityFrameworkCore;
using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Expenses
{
    public class EfCoreExpenseRepository : EfCoreCommonRepository<Expense>, IExpenseRepository
    {
        public EfCoreExpenseRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Expense>> WithDetailsAsync()
        {
            return (await GetQueryableAsync())
                                .Include(x => x.Unit)
                                .Include(x => x.SpecialCodeOne)
                                .Include(x => x.SpecialCodeTwo)
                                .Include(x => x.InvoiceDetails).ThenInclude(x => x.Invoice);
        }
    }
}
