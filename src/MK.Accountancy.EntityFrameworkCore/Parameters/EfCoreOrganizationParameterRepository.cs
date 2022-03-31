using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Parameters
{
    public class EfCoreOrganizationParameterRepository : EfCoreCommonRepository<OrganizationParameter>, IOrganizationParameterRepository
    {
        public EfCoreOrganizationParameterRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
