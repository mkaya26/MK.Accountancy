using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Departments;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class DepartmentService : BaseService<ListDepartmentDto,SelectDepartmentDto>,IScopedDependency
    {
    }
}
