using MK.Accountancy.Blazor.Services;
using System.Threading.Tasks;
using System.Linq;
using MK.Accountancy.Receipts;
using System;
using System.Collections.Generic;

namespace MK.Accountancy.Blazor.Pages.Receipts
{
    public partial class CollectionReceiptListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            var listDataSource = (await GetListAsync(new ReceiptListParameterDto
            {
                ReceiptType = ReceiptType.Collection,
                DepartmentId = AppService.CompanyParameter.DepartmentId,
                TermId = AppService.CompanyParameter.TermId,
                Active = Service.IsActiveCards
            }))?.Items.ToList();
            //
            Service.IsLoaded = true;
            //
            if (listDataSource != null)
                Service.ListDataSource = listDataSource;
        }

        protected override async Task BeforeInsertAsync()
        {
            Service.DataSource = new SelectReceiptDto
            {
                ReceiptNumber = await GetCodeAsync(new ReceiptNumberParameterDto
                {
                    ReceiptType = ReceiptType.Collection,
                    DepartmentId = AppService.CompanyParameter.DepartmentId,
                    TermId = AppService.CompanyParameter.TermId,
                    Active = Service.IsActiveCards
                }
                ),
                ReceiptType = ReceiptType.Collection,
                ReceiptDate = DateTime.Now.Date,
                DepartmentId = AppService.CompanyParameter.DepartmentId,
                TermId = AppService.CompanyParameter.TermId,
                Active = Service.IsActiveCards,
                receiptDetails = new List<SelectReceiptDetailDto>()
            };
            //
            Service.ShowEditPage();
            //
            await Task.CompletedTask;
        }
    }
}
