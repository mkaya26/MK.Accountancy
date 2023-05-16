using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Receipts;
using MK.Accountancy.Safes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class SafeService : BaseService<ListSafeDto,SelectSafeDto>,IScopedDependency
    {
        public override void SelectEntity(IEntityDto targetEntity)
        {
            switch (targetEntity)
            {
                case SelectReceiptDetailDto receiptDetailDto:
                    receiptDetailDto.SafeId = SelectedItem.Id;
                    receiptDetailDto.SafeName = SelectedItem.Name;
                    break;
                case SelectReceiptDto receiptDto:
                    receiptDto.SafeId = SelectedItem.Id;
                    receiptDto.SafeName = SelectedItem.Name;
                    break;
            }
        }
    }
}
