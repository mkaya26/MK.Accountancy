using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.PaymentDocuments;
using MK.Accountancy.Receipts;
using System;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class PaymentDocumentMoventService : BaseService<ListPaymentDocumentMoventDto,SelectReceiptDetailDto>,IScopedDependency
    {
        public PaymentType PaymentType { get; set; }
        public Guid EntityId { get; set; }
        public override void BeforeShowPopupListPage(params object[] parameters)
        {
            IsPopupListPage = true;
            PaymentType = (PaymentType)parameters[0];
            EntityId = (Guid)parameters[1];
        }
    }
}
