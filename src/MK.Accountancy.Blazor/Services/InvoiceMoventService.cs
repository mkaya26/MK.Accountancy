using MK.Accountancy.Blazor.Helpers;
using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Invoices;
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
    }
}
