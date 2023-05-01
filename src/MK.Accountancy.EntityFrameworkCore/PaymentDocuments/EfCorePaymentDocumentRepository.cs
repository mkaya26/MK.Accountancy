using MK.Accountancy.Commons;
using MK.Accountancy.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.PaymentDocuments
{
    public class EfCorePaymentDocumentRepository : EfCoreCommonRepository<PaymentDocument>, IPaymentDocumentRepository
    {
        public EfCorePaymentDocumentRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
