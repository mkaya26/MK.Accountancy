using Microsoft.AspNetCore.Authorization;
using MK.Accountancy.CommonDtos;
using MK.Accountancy.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Services
{
    [Authorize(AccountancyPermissions.Service.Default)]
    public class ServiceAppService : AccountancyAppService, IServiceAppService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ServiceManager _serviceManager;

        public ServiceAppService(IServiceRepository serviceRepository, ServiceManager serviceManager)
        {
            _serviceRepository = serviceRepository;
            _serviceManager = serviceManager;
        }
        [Authorize(AccountancyPermissions.Service.Create)]
        public virtual async Task<SelectServiceDto> CreateAsync(CreateServiceDto input)
        {
            await _serviceManager.CheckCreateAsync(input.Code, input.SpecialCodeOneId, input.SpecialCodeTwoId, input.UnitId);
            //
            var entity = ObjectMapper.Map<CreateServiceDto, Service>(input);
            await _serviceRepository.InsertAsync(entity);
            return ObjectMapper.Map<Service, SelectServiceDto>(entity);
        }
        [Authorize(AccountancyPermissions.Service.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _serviceManager.CheckDeleteAsync(id);
            //
            await _serviceRepository.DeleteAsync(id);
        }

        public virtual async Task<SelectServiceDto> GetAsync(Guid id)
        {
            var entity = await _serviceRepository.GetAsync(id, f => f.Id == id);
            return ObjectMapper.Map<Service, SelectServiceDto>(entity);
        }

        public virtual async Task<string> GetCodeAsync(CodeParameterDto input)
        {
            return await _serviceRepository.GetCodeAsync(p => p.Code, f => f.Active == input.Active);
        }

        public virtual async Task<PagedResultDto<ListServiceDto>> GetListAsync(ServiceListParameterDto input)
        {
            var entities = await _serviceRepository.GetPagedListAsync(
                                                    input.SkipCount,
                                                    input.MaxResultCount,
                                                    f => f.Active == input.Active,
                                                    o => o.Code);
            var totalCount = await _serviceRepository.CountAsync(f => f.Active == input.Active);
            //
            return new PagedResultDto<ListServiceDto>(totalCount, ObjectMapper.Map<List<Service>, List<ListServiceDto>>(entities));
        }
        [Authorize(AccountancyPermissions.Service.Update)]
        public virtual async Task<SelectServiceDto> UpdateAsync(Guid id, UpdateServiceDto input)
        {
            var entity = await _serviceRepository.GetAsync(id, f => f.Id == id);
            //
            await _serviceManager.CheckUpdateAsync(id, input.Code, entity, input.SpecialCodeOneId, input.SpecialCodeTwoId, input.UnitId);
            //
            var mappedEntity = ObjectMapper.Map(input, entity);
            await _serviceRepository.UpdateAsync(mappedEntity);
            return ObjectMapper.Map<Service, SelectServiceDto>(mappedEntity);
        }
    }
}
