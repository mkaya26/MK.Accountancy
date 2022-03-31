using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.BankAccounts
{
    public class EfCoreBankAccountRepository : EfCoreCommonRepository<BankAccount>, IBankAccountRepository
    {
        public EfCoreBankAccountRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
