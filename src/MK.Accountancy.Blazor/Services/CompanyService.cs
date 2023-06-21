using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Companies;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class CompanyService : BaseService<SelectCompanyDto, ListCompanyDto>, IScopedDependency
    {
    }
}
