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
            DepartmentId = new Guid("341ead12-91e3-7afa-e530-3a09198d32f1"),
            TermId = new Guid("e42697df-c3e4-efcb-ac49-3a09198a8c42")
        };
        public Action HasChanged { get; set; }
        public bool ShowOrganizationParameterEditPage { get; set; }
        public bool ShowDepartmentTermEditPage { get; set; }
    }
}
