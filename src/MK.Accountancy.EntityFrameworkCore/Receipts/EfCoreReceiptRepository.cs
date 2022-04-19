using Microsoft.EntityFrameworkCore;
using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Receipts
{
    public class EfCoreReceiptRepository : EfCoreCommonRepository<Receipt>, IReceiptRepository
    {
        public EfCoreReceiptRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Receipt>> WithDetailsAsync()
        {
            return (await GetQueryableAsync())
                            .Include(i => i.Current)
                            .Include(i => i.Safe)
                            .Include(i => i.BankAccount)
                            .Include(i => i.SpecialCodeOne)
                            .Include(i => i.SpecialCodeTwo)
                            .Include(i => i.ReceiptDetails).ThenInclude(i => i.ChequeBank)
                            .Include(i => i.ReceiptDetails).ThenInclude(i => i.ChequeBankDepartment)
                            .Include(i => i.ReceiptDetails).ThenInclude(i => i.Safe)
                            .Include(i => i.ReceiptDetails).ThenInclude(i => i.BankAccount);
        }
    }
}
