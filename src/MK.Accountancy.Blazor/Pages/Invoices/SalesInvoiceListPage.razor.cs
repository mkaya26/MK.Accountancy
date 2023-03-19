using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Invoices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace MK.Accountancy.Blazor.Pages.Invoices
{
    public partial class SalesInvoiceListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            Service.ListDataSource = (await GetListAsync(new InvoiceListParameterDto
            {
                InvoiceType = InvoiceType.Sell,
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
                InvoiceNumber = await GetCodeAsync(new InvoiceNumberParameterDto
                {
                    InvoiceType = InvoiceType.Sell,
                    DepartmentId = AppService.CompanyParameter.DepartmentId,
                    TermId = AppService.CompanyParameter.TermId,
                    Active = Service.IsActiveCards
                }),
                InvoiceType = InvoiceType.Sell,
                InvoiceDate = DateTime.Now.Date,
                DepartmentId = AppService.CompanyParameter.DepartmentId,
                TermId = AppService.CompanyParameter.TermId,
                Active = Service.IsActiveCards,
                InvoiceDetails = new List<SelectInvoiceDetailDto>()
            };
            //
            Service.ShowEditPage();
        }
    }
}
