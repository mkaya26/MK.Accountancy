using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Parameters;
using MK.Accountancy.Terms;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class TermService : BaseService<ListTermDto,SelectTermDto>,IScopedDependency
    {
        public override void SelectEntity(IEntityDto targetEntity)
        {
            switch (targetEntity)
            {
                case SelectOrganizationParameterDto parameterDto:
                    parameterDto.TermId = SelectedItem.Id;
                    parameterDto.TermName = SelectedItem.Name;
                    break;
            }
        }
    }
}
