using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.BankDepartments
{
    public class EfCoreBankDepartmentRepository : EfCoreCommonRepository<BankDepartment>, IBankDepartmentRepository
    {
        public EfCoreBankDepartmentRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
