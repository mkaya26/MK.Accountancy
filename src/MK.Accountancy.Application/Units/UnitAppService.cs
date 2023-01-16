using MK.Accountancy.CommonDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Units
{
    public class UnitAppService : AccountancyAppService, IUnitAppService
    {
        private readonly IUnitRepository _unitRepository;
        private readonly UnitManager _unitManager;

        public UnitAppService(IUnitRepository unitRepository, UnitManager unitManager)
        {
            _unitRepository = unitRepository;
            _unitManager = unitManager;
        }

        public virtual async Task<SelectUnitDto> CreateAsync(CreateUnitDto input)
        {
            await _unitManager.CheckCreateAsync(input.Code, input.SpecialCodeOneId, input.SpecialCodeTwoId);
            //
            var entity = ObjectMapper.Map<CreateUnitDto,Unit>(input);
            await _unitRepository.InsertAsync(entity);
            return ObjectMapper.Map<Unit,SelectUnitDto>(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _unitManager.CheckDeleteAsync(id);
            //
            await _unitRepository.DeleteAsync(id);
        }

        public virtual async Task<SelectUnitDto> GetAsync(Guid id)
        {
            var entity = await _unitRepository.GetAsync(id, x => x.Id == id, x => x.SpecialCodeOne, x => x.SpecialCodeTwo);
            return ObjectMapper.Map<Unit, SelectUnitDto>(entity);
        }

        public virtual async Task<string> GetCodeAsync(CodeParameterDto input)
        {
            return await _unitRepository.GetCodeAsync(x => x.Code, x => x.Active == input.Active);
        }

        public virtual async Task<PagedResultDto<ListUnitDto>> GetListAsync(UnitListParameterDto input)
        {
            var entities = await _unitRepository.GetPagedListAsync(
                           input.SkipCount,
                           input.MaxResultCount,
                           x => x.Active == input.Active,
                           x => x.Code,
                           x => x.SpecialCodeOne, x => x.SpecialCodeTwo);
            //
            var totalCount = await _unitRepository.CountAsync(x => x.Active == input.Active);
            //
            return new PagedResultDto<ListUnitDto>(
                           totalCount,
                           ObjectMapper.Map<List<Unit>, List<ListUnitDto>>(entities));
        }

        public virtual async Task<SelectUnitDto> UpdateAsync(Guid id, UpdateUnitDto input)
        {
            var entity = await _unitRepository.GetAsync(id, x => x.Id == id);
            //
            await _unitManager.CheckUpdateAsync(id, input.Code, entity, input.SpecialCodeOneId, input.SpecialCodeTwoId);
            //
            var mappedEntity = ObjectMapper.Map(input,entity);
            await _unitRepository.UpdateAsync(mappedEntity);
            return ObjectMapper.Map<Unit,SelectUnitDto>(mappedEntity);
        }
    }
}
