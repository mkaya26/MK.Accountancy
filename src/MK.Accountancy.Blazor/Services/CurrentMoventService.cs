using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Currents;
using MK.Accountancy.Receipts;
using System;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class CurrentMoventService : BaseService<ListCurrentMoventDto,SelectReceiptDetailDto>, IScopedDependency
    {
        public Guid CurrentId { get; set; }
        public override void BeforeShowPopupListPage(params object[] parameters)
        {
            IsPopupListPage = true;
            CurrentId = (Guid)parameters[0];
        }
    }
}
