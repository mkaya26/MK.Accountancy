using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Receipts;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class ReceiptService : BaseService<ListReceiptDto,SelectReceiptDto>,IScopedDependency
    {
        public ReceiptType ReceiptType { get; set; }
    }
}
