using MK.Accountancy.Abstract;

namespace MK.Accountancy.Parameters
{
    public interface IOrganizationParameterAppService : ICrudAppService<SelectOrganizationParameterDto, SelectOrganizationParameterDto, OrganizationParameterListParameterDto, CreateOrganizationParameterDto, UpdateOrganizationParameterDto>
    {
    }
}
