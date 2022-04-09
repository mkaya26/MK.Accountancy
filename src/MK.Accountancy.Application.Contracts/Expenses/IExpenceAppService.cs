using MK.Accountancy.Abstract;
using MK.Accountancy.CommonDtos;

namespace MK.Accountancy.Expenses
{
    public interface IExpenceAppService : ICrudAppService<SelectExpenseDto, ListExpenseDto, ExpenseListParameterDto, CreateExpenseDto, UpdateExpenseDto, CodeParameterDto>
    {
    }
}
