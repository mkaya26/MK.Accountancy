using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Currents;
using MK.Accountancy.Expenses;
using MK.Accountancy.Invoices;
using MK.Accountancy.Services;
using MK.Accountancy.Stocks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class CurrentService : BaseService<ListCurrentDto,SelectCurrentDto>,IScopedDependency
    {
        public override void SelectEntity(IEntityDto targetEntity)
        {
            switch (targetEntity)
            {
                case SelectInvoiceDto serviceDto:
                    serviceDto.CurrentId = SelectedItem.Id;
                    serviceDto.CurrentName = SelectedItem.Name;
                    break;
            }
        }
    }
}
