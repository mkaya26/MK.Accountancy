using MK.Accountancy.BankAccounts;
using MK.Accountancy.Banks;
using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Receipts;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class BankService : BaseService<BankListDto,SelectBankDto>,IScopedDependency
    {
        public override void SelectEntity(IEntityDto targetEntity)
        {
            switch (targetEntity)
            {
                case SelectBankAccountDto bankAccountDto:
                    bankAccountDto.BankId = SelectedItem.Id;
                    bankAccountDto.BankName = SelectedItem.Name;
                    break;
                case SelectReceiptDetailDto receiptDetailDto:
                    receiptDetailDto.ChequeBankId = SelectedItem.Id;
                    receiptDetailDto.ChequeBankName = SelectedItem.Name;
                    break;
            }
        }
    }
}
