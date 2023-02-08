using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Departments;
using MK.Accountancy.Parameters;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class DepartmentService : BaseService<ListDepartmentDto,SelectDepartmentDto>,IScopedDependency
    {
        public override void SelectEntity(IEntityDto targetEntity)
        {
            switch (targetEntity)
            {
                case SelectOrganizationParameterDto parameterDto:
                    parameterDto.DepartmentId = SelectedItem.Id;
                    parameterDto.DepartmentName = SelectedItem.Name;
                    break;
            }
        }
    }
}
