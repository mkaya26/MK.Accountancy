﻿using MK.Accountancy.BankAccounts;
using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Receipts;
using MK.Blazor.Core.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class BankAccountService : BaseService<ListBankAccountDto, SelectBankAccountDto>,
    IScopedDependency
    {
        public BankAccountType? BankAccountType { get; set; }
        public void BankAccountTypeSelectedItemChanged(ComboboxEnumItem<BankAccountType> selectedItem)
        {
            DataSource.BankAccountType = selectedItem.Value;
        }

        public override void SelectEntity(IEntityDto targetEntity)
        {
            switch (targetEntity)
            {
                case SelectReceiptDetailDto receiptDetailDto:
                    receiptDetailDto.BankAccountId = SelectedItem.Id;
                    receiptDetailDto.BankAccountIdName = SelectedItem.Name;
                    break;
                case SelectReceiptDto receiptDto:
                    receiptDto.BankAccountId = SelectedItem.Id;
                    receiptDto.BankAccountName = SelectedItem.Name;
                    break;
            }
        }
    }
}
