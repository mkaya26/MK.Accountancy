using MK.Accountancy.BankDepartments;
using MK.Accountancy.Blazor.Services.Base;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class BankDepartmentService : BaseService<ListBankDepartmentDto,SelectBankDepartmentDto>,IScopedDependency
    {
    }
}
