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
            TermId = new Guid("E42697DF-C3E4-EFCB-AC49-3A09198A8C42")
        };
        public Action HasChanged { get; set; }
        public bool ShowOrganizationParameterEditPage { get; set; }
        public bool ShowDepartmentTermEditPage { get; set; }
    }
}
