using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Services;
using MK.Accountancy.Units;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class UnitService : BaseService<ListUnitDto,SelectUnitDto>,IScopedDependency
    {
        public override void SelectEntity(IEntityDto targetEntity)
        {
            if(targetEntity is SelectServiceDto serviceDto)
            {
                serviceDto.UnitId = SelectedItem.Id;
                serviceDto.UnitName = SelectedItem.Name;
            }
        }
    }
}
