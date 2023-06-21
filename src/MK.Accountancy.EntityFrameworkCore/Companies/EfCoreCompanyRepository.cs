using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Companies
{
    public class EfCoreCompanyRepository : EfCoreCommonRepository<Company>, ICompanyRepository
    {
        public EfCoreCompanyRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
