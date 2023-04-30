using MK.Accountancy.Blazor.Helpers;
using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Invoices;
using MK.Accountancy.Receipts;
using MK.Blazor.Core.Models;
using System;
using System.Linq;
using Volo.Abp.DependencyInjection;
using static MK.Blazor.Core.Helpers.Functions;

namespace MK.Accountancy.Blazor.Services
{
    public class ReceiptMoventService : BaseMoventService<SelectReceiptDetailDto>, IScopedDependency
    {
        public ReceiptService ReceiptService { get; set; }
        public AppService AppService { get; set; }

        public override void BeforeUpdate()
        {
            if(ReceiptService.ReceiptType == ReceiptType.Collection || (SelectedItem.DocumentStatu != DocumentStatu.Endorsed && SelectedItem.DocumentStatu != DocumentStatu.Collected))
            {
                DataSource = SelectedItem;
                EditPageVisible = true;
            }
        }

        public override void BeforeInsert()
        {
            DataSource = new SelectReceiptDetailDto
            {
                PaymentType = PaymentType.Cheque,
                ExpiryDate = DateTime.Now.Date,
                TrackingNumber = CreateId()
            };
            EditPageVisible = true;
        }

        public void ReceiptMoventTypeSelectedItemChanged(ComboboxEnumItem<PaymentType> selectedItem, Action hasChenaged)
        {
            TempDataSource.PaymentType = selectedItem.Value;
            hasChenaged();
            //
            TempDataSource.ChequeBankId = null;
            TempDataSource.ChequeBankName = null;
            TempDataSource.ChequeBankDepartmentId = null;
            TempDataSource.ChequeBankDepartmentName = null;
            TempDataSource.ChequeAccountNumber = null;
            TempDataSource.DocumentNo = null;
            TempDataSource.PrincipalDebtor = null;
            TempDataSource.Endorser = null;
            TempDataSource.SafeId = null;
            TempDataSource.SafeName = null;
            TempDataSource.BankAccountId = null;
            TempDataSource.BankAccountIdName = null;
        }

        public override void OnSubmit()
        {
            var validator = new SelectReceiptMoventValidator(L);
            var result = validator.Validate(TempDataSource);
            //
            if (result.IsValid)
            {
                DataSource = TempDataSource;
                DataSource.PaymentTypeName = L[$"Enum:PaymentType:{(byte)DataSource.PaymentType}"];
                DataSource.DocumentStatu = ReceiptService.ReceiptType == ReceiptType.Collection && (DataSource.PaymentType == PaymentType.Cash || DataSource.PaymentType == PaymentType.Bank) ? DocumentStatu.Collected : ReceiptService.ReceiptType == ReceiptType.Collection && (DataSource.PaymentType == PaymentType.Bill || DataSource.PaymentType == PaymentType.Cheque || DataSource.PaymentType == PaymentType.Pos) ? DocumentStatu.InPortfolio : ReceiptService.ReceiptType == ReceiptType.Payment && (DataSource.PaymentType == PaymentType.Cash || DataSource.PaymentType == PaymentType.Bank) ? DocumentStatu.Paid :
                    ReceiptService.ReceiptType == ReceiptType.Payment && (DataSource.PaymentType == PaymentType.Bill || DataSource.PaymentType == PaymentType.Cheque || DataSource.PaymentType == PaymentType.Pos) ? DocumentStatu.Payable : DocumentStatu.Endorsed;
                //
                DataSource.DocumentStatuName = L[$"Enum:DocumentStatu:{(byte)DataSource.DocumentStatu}"];
                DataSource.MyDocument = DataSource.DocumentStatu == DocumentStatu.Payable;
                //
                InsertOrUpdate();
                HasChanged();
            }
            else
            {
                MessageService.Error(result.Errors.CreateValidationErrorMessage(L));
            }
        }
        public override void GetTotal()
        {
            ReceiptService.DataSource.ChequeTotal = ListDataSource.Where(x => x.PaymentType == PaymentType.Cheque).Sum(x => x.Price);
            ReceiptService.DataSource.BillTotal = ListDataSource.Where(x => x.PaymentType == PaymentType.Bill).Sum(x => x.Price);
            ReceiptService.DataSource.CashTotal = ListDataSource.Where(x => x.PaymentType == PaymentType.Cash).Sum(x => x.Price);
            ReceiptService.DataSource.BankTotal = ListDataSource.Where(x => x.PaymentType == PaymentType.Bank).Sum(x => x.Price);
            ReceiptService.DataSource.PostTotal = ListDataSource.Where(x => x.PaymentType == PaymentType.Pos).Sum(x => x.Price);
            ReceiptService.DataSource.MovementNumber = ListDataSource.Count;
            //
            HasChanged();
        }
    }
}
