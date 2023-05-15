using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.PaymentDocuments;
using MK.Accountancy.Receipts;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class PaymentDocumentService : BaseService<ListPaymentDocumentDto,SelectReceiptDetailDto>,IScopedDependency
    {
        public AppService AppService { get; set; }
        public ReceiptService ReceiptService { get; set; }
        public string PaymentTypes { get; set; }
        public bool MyDocument { get; set; }
    }
}
