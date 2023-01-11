using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Expenses;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class ExpenseService : BaseService<ListExpenseDto,SelectExpenseDto>,IScopedDependency
    {
    }
}
