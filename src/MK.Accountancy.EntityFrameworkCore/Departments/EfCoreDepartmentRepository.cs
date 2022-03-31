using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Departments
{
    public class EfCoreDepartmentRepository : EfCoreCommonRepository<Department>, IDepartmentRepository
    {
        public EfCoreDepartmentRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
