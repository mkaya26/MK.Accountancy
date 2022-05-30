using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Parameters
{
    public class OrganizationParameterAppService : AccountancyAppService, IOrganizationParameterAppService
    {
        private readonly IOrganizationParameterRepository _organizationParameterRepository;
        private readonly OrganizationParameterManager _organizationParameterManager;

        public OrganizationParameterAppService(IOrganizationParameterRepository organizationParameterRepository, OrganizationParameterManager organizationParameterManager)
        {
            _organizationParameterRepository = organizationParameterRepository;
            _organizationParameterManager = organizationParameterManager;
        }

        public virtual async Task<SelectOrganizationParameterDto> CreateAsync(CreateOrganizationParameterDto input)
        {
            await _organizationParameterManager.CheckCreateAsync(input.TermId, input.DepartmentId, input.StoryId);
            //
            var entity = ObjectMapper.Map<CreateOrganizationParameterDto, OrganizationParameter>(input);
            await _organizationParameterRepository.InsertAsync(entity);
            //
            return ObjectMapper.Map<OrganizationParameter,SelectOrganizationParameterDto>(entity);
        }

        public virtual async Task<SelectOrganizationParameterDto> GetAsync(Guid userId)
        {
            var entity = await _organizationParameterRepository.GetAsync(x => x.UserId == userId, i => i.Department, i => i.Term, i => i.Store);
            //
            if (entity == null) return null;
            //
            return ObjectMapper.Map<OrganizationParameter,SelectOrganizationParameterDto>(entity);
        }

        [NonAction]
        public virtual Task<PagedResultDto<SelectOrganizationParameterDto>> GetListAsync(OrganizationParameterListParameterDto input)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<SelectOrganizationParameterDto> UpdateAsync(Guid userId, UpdateOrganizationParameterDto input)
        {
            var entity = await _organizationParameterRepository.GetAsync(userId, x => x.UserId == userId);
            //
            await _organizationParameterManager.CheckUpdateAsync(input.TermId, input.DepartmentId, input.StoryId);
            //
            var mappedEntity = ObjectMapper.Map(input, entity);
            //
            await _organizationParameterRepository.UpdateAsync(mappedEntity);
            //
            return ObjectMapper.Map<OrganizationParameter, SelectOrganizationParameterDto>(mappedEntity);
        }

        [NonAction]
        public virtual async Task<bool> UserAnyAsync(Guid userId)
        {
            return await _organizationParameterRepository.AnyAsync(x => x.UserId == userId);
        }
    }
}
