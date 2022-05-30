using MK.Accountancy.Abstract;
using System;
using System.Threading.Tasks;

namespace MK.Accountancy.Parameters
{
    public interface IOrganizationParameterAppService : ICrudAppService<SelectOrganizationParameterDto, SelectOrganizationParameterDto, OrganizationParameterListParameterDto, CreateOrganizationParameterDto, UpdateOrganizationParameterDto>
    {
        Task<bool> UserAnyAsync(Guid userId);
    }
}
