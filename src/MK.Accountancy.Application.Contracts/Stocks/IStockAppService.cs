using MK.Accountancy.Abstract;
using MK.Accountancy.CommonDtos;

namespace MK.Accountancy.Stocks
{
    public interface IStockAppService : ICrudAppService<SelectStockDto, ListStockDto, StockListParameterDto, CreateStockDto, UpdateStockDto, CodeParameterDto>
    {
    }
}
