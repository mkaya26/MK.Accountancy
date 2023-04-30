using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Receipts;
using MK.Blazor.Core.Services;
using System.Collections.Generic;
using System;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class ReceiptService : BaseService<ListReceiptDto,SelectReceiptDto>,IScopedDependency
    {
        public ReceiptType ReceiptType { get; set; }

        public override void FillTable<TItem>(ICoreMoventService<TItem> moventService, Action hasChanged)
        {
            if (moventService is ReceiptMoventService receiptMoventService)
            {
                receiptMoventService.ListDataSource = DataSource.receiptDetails ?? new List<SelectReceiptDetailDto>();
                receiptMoventService.HasChanged = hasChanged;
                receiptMoventService.GetTotal();
            }
        }
    }
}
