using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MK.Accountancy.Blazor.Pages.Invoices
{
    public partial class PurchaseInvoiceListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            Service.ListDataSource = (await GetListAsync(new InvoiceListParameterDto
            {
                InvoiceType = InvoiceType.Buy,
                DepartmentId = AppService.CompanyParameter.DepartmentId,
                TermId = AppService.CompanyParameter.TermId,
                Active = Service.IsActiveCards
            })).Items.ToList();
            //
            Service.IsLoaded = true;
        }

        protected override async Task BeforeInsertAsync()
        {
            Service.DataSource = new SelectInvoiceDto
            {
                InvoiceType = InvoiceType.Buy,
                InvoiceDate = DateTime.Now.Date,
                DepartmentId = AppService.CompanyParameter.DepartmentId,
                TermId = AppService.CompanyParameter.TermId,
                Active = Service.IsActiveCards,
                InvoiceDetails = new List<SelectInvoiceDetailDto>()
            };
            //
            Service.ShowEditPage();
            //
            await Task.CompletedTask;
        }
    }
}
