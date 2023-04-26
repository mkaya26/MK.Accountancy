using MK.Accountancy.Blazor.Helpers;
using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Invoices;
using MK.Blazor.Core.Models;
using System;
using System.Linq;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class InvoiceMoventService : BaseMoventService<SelectInvoiceDetailDto>, IScopedDependency
    {
        public InvoiceService InvoiceService { get; set; }
        public AppService AppService { get; set; }
        public override void GetTotal()
        {
            InvoiceService.DataSource.GrandTotal = ListDataSource.Sum(x => x.GrossAmount);
            InvoiceService.DataSource.DiscountTotal = ListDataSource.Sum(x => x.DiscountAmount);
            InvoiceService.DataSource.Netamount = ListDataSource.Sum(x => x.NetTotal);
            InvoiceService.DataSource.TaxAmount = ListDataSource.Sum(x => x.TaxTotal);
            InvoiceService.DataSource.SubTotal = ListDataSource.Sum(x => x.SubTotal);
            InvoiceService.DataSource.MovementNumber = ListDataSource.Count;
        }

        public override void BeforeInsert()
        {
            DataSource = new SelectInvoiceDetailDto
            {
                StoreId = AppService.CompanyParameter.StoryId,
                StoreName = AppService.CompanyParameter.StoryName,
                InvoiceDetailType = InvoiceDetailType.Stock
            };
            //
            EditPageVisible = true;
        }

        public override void OnSubmit()
        {
            var validator = new SelectInvoiceDetailDtoValidator(L);
            var result = validator.Validate(TempDataSource);
            //
            if(result.IsValid)
            {
                DataSource = TempDataSource;
                DataSource.InvoiceDetailTypeName = L[$"Enum:InvoiceDetailType:{(byte)DataSource.InvoiceDetailType}"];
                //
                InsertOrUpdate();
                HasChanged();
            }
            else
            {
                MessageService.Error(result.Errors.CreateValidationErrorMessage(L));
            }
        }

        public void InvoiceMoventTypeSelectedItemChanged(ComboboxEnumItem<InvoiceDetailType> selectedItem,Action hasChenaged)
        {
            TempDataSource.InvoiceDetailType = selectedItem.Value;
            hasChenaged();
            //
            TempDataSource.StockId = null;
            TempDataSource.StockName = null;
            TempDataSource.StockCode = null;
            //
            TempDataSource.ServiceId = null;
            TempDataSource.ServiceName = null;
            TempDataSource.ServiceCode = null;
            //
            TempDataSource.ExpenseId = null;
            TempDataSource.ExpenceName = null;
            TempDataSource.ExpenceCode = null;
            //
            TempDataSource.UnitPrice = 0;
            TempDataSource.TaxRate = 0;
            //
            if(TempDataSource.InvoiceDetailType == InvoiceDetailType.Stock)
            {
                TempDataSource.StoreId = AppService.CompanyParameter.StoryId;
                TempDataSource.StoreName = AppService.CompanyParameter.StoryName;
            }
            else
            {
                TempDataSource.StoreId = null;
                TempDataSource.StoreName = null;
            }
        }

        public override void Calc(object value, string propertyName)
        {
            TempDataSource.GetType().GetProperty(propertyName).SetValue(TempDataSource, value);
            //
            TempDataSource.GrossAmount = TempDataSource.Quantity * TempDataSource.UnitPrice;
            TempDataSource.DiscountAmount = TempDataSource.DiscountAmount > TempDataSource.GrossAmount ?
                TempDataSource.GrossAmount :
                TempDataSource.DiscountAmount;
            TempDataSource.SubTotal = (TempDataSource.Quantity * TempDataSource.UnitPrice) - TempDataSource.DiscountAmount;
            TempDataSource.TaxTotal = TempDataSource.SubTotal * TempDataSource.TaxRate / 100;
            TempDataSource.NetTotal = TempDataSource.SubTotal + TempDataSource.TaxTotal;
        }
    }
}
