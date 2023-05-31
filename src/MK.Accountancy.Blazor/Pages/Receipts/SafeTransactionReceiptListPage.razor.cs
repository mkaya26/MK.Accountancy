using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace MK.Accountancy.Blazor.Pages.Receipts
{
    public partial class SafeTransactionReceiptListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            var listDataSource = (await GetListAsync(new ReceiptListParameterDto
            {
                ReceiptType = ReceiptType.SafeOperation,
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
                    ReceiptType = ReceiptType.SafeOperation,
                    DepartmentId = AppService.CompanyParameter.DepartmentId,
                    TermId = AppService.CompanyParameter.TermId,
                    Active = Service.IsActiveCards
                }
                ),
                ReceiptType = ReceiptType.SafeOperation,
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
