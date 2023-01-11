using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Stocks;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class StockService : BaseService<ListStockDto,SelectStockDto>,IScopedDependency
    {
    }
}
