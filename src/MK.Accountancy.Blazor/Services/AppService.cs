using MK.Accountancy.Parameters;
using MK.Blazor.Core.Services;
using System;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class AppService : ICoreAppService, IScopedDependency
    {
        public SelectOrganizationParameterDto CompanyParameter { get; set; } = new SelectOrganizationParameterDto
        {
            DepartmentId = new Guid("7576E653-C679-17E3-C633-3A0A096A8B0D"),
            TermId = new Guid("F8567095-CAF9-24BD-2D1F-3A0A096A4D77")
        };
        public Action HasChanged { get; set; }
        public bool ShowOrganizationParameterEditPage { get; set; }
        public bool ShowDepartmentTermEditPage { get; set; }
    }
}
