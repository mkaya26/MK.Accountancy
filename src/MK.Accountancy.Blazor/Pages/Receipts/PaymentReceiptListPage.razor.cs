using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace MK.Accountancy.Blazor.Pages.Receipts
{
    public partial class PaymentReceiptListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            Service.ListDataSource = (await GetListAsync(new ReceiptListParameterDto
            {
                ReceiptType = ReceiptType.Payment,
                DepartmentId = AppService.CompanyParameter.DepartmentId,
                TermId = AppService.CompanyParameter.TermId,
                Active = Service.IsActiveCards
            })).Items.ToList();
            //
            Service.IsLoaded = true;
        }

        protected override async Task BeforeInsertAsync()
        {
            Service.DataSource = new SelectReceiptDto
            {
                ReceiptNumber = await GetCodeAsync(new ReceiptNumberParameterDto
                {
                    ReceiptType = ReceiptType.Payment,
                    DepartmentId = AppService.CompanyParameter.DepartmentId,
                    TermId = AppService.CompanyParameter.TermId,
                    Active = Service.IsActiveCards
                }
                ),
                ReceiptType = ReceiptType.Payment,
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
