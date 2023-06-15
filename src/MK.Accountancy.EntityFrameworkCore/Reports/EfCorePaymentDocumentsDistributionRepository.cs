using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Reports
{
    public class EfCorePaymentDocumentsDistributionRepository : EfCoreCommonNoKeyRepository<PaymentDocumentsDistribution>, IPaymentDocumentsDistributionRepository
    {
        public EfCorePaymentDocumentsDistributionRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
