using Volo.Abp.Application.Dtos;

namespace MK.Blazor.Core.Services
{
    public interface ICoreAppService
    {
        public IEntityDto CompanyParameter { get; set; }
        public Action HasChanged { get; set; }
        public bool ShowOrganizationParameterEditPage { get; set; }
        public bool ShowDepartmentTermEditPage { get; set; }
    }
}
