using MK.Accountancy.Parameters;
using MK.Blazor.Core.Services;
using System;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class AppService : ICoreAppService, IScopedDependency
    {
        public SelectOrganizationParameterDto CompanyParameter { get; set; } = new SelectOrganizationParameterDto();
        public Action HasChanged { get; set; }
        public bool ShowOrganizationParameterEditPage { get; set; }
        public bool ShowDepartmentTermEditPage { get; set; }
    }
}
