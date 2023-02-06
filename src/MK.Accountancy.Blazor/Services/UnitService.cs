using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Expenses;
using MK.Accountancy.Services;
using MK.Accountancy.Stocks;
using MK.Accountancy.Units;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class UnitService : BaseService<ListUnitDto,SelectUnitDto>,IScopedDependency
    {
        public override void SelectEntity(IEntityDto targetEntity)
        {
            switch (targetEntity)
            {
                case SelectServiceDto serviceDto:
                    serviceDto.UnitId = SelectedItem.Id;
                    serviceDto.UnitName = SelectedItem.Name;
                    break;
                case SelectExpenseDto expenseDto:
                    expenseDto.UnitId = SelectedItem.Id;
                    expenseDto.UnitName = SelectedItem.Name;
                    break;
                case SelectStockDto stockDto:
                    stockDto.UnitId = SelectedItem.Id;
                    stockDto.UnitName = SelectedItem.Name;
                    break;
            }
        }
    }
}
