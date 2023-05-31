using Microsoft.AspNetCore.Authorization;
using MK.Accountancy.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.SpecialCodes
{
    [Authorize(AccountancyPermissions.SpecialCode.Default)]
    public class SpecialCodeAppService : AccountancyAppService, ISpecialCodeAppService
    {
        private readonly ISpecialCodeRepository _specialCodeRepository;
        private readonly SpecialCodeManager _specialCodeManager;

        public SpecialCodeAppService(ISpecialCodeRepository specialCodeRepository, SpecialCodeManager specialCodeManager)
        {
            _specialCodeRepository = specialCodeRepository;
            _specialCodeManager = specialCodeManager;
        }
        [Authorize(AccountancyPermissions.SpecialCode.Create)]
        public virtual async Task<SelectSpecialCodeDto> CreateAsync(CreateSpecialCodeDto input)
        {
            await _specialCodeManager.CheckCreateAsync(input.Code, input.SpecialCodeType, input.CardType);
            //
            var entity = ObjectMapper.Map<CreateSpecialCodeDto, SpecialCode>(input);
            await _specialCodeRepository.InsertAsync(entity);
            return ObjectMapper.Map<SpecialCode, SelectSpecialCodeDto>(entity);
        }
        [Authorize(AccountancyPermissions.SpecialCode.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _specialCodeManager.CheckDeleteAsync(id);
            //
            await _specialCodeRepository.DeleteAsync(id);
        }

        public virtual async Task<SelectSpecialCodeDto> GetAsync(Guid id)
        {
            var entity = await _specialCodeRepository.GetAsync(id, x => x.Id == id);
            return ObjectMapper.Map<SpecialCode, SelectSpecialCodeDto>(entity);
        }

        public virtual async Task<string> GetCodeAsync(SpecialCodeParameterDto input)
        {
            return await _specialCodeRepository.GetCodeAsync(x => x.Code, f => f.CardType == input.CardType && f.SpecialCodeType == input.SpecialCodeType && f.Active == input.Active);
        }

        public virtual async Task<PagedResultDto<ListSpecialCodeDto>> GetListAsync(SpecialCodeListParameterDto input)
        {
            var entities = await _specialCodeRepository.GetPagedListAsync(
                input.SkipCount,
                input.MaxResultCount,
                x => x.Active == input.Active
                && x.SpecialCodeType == input.SpecialCodeType
                && x.CardType == input.CardType,
                x => x.Code);
            //
            var totalCount = await _specialCodeRepository.CountAsync(x => x.Active == input.Active
                && x.SpecialCodeType == input.SpecialCodeType
                && x.CardType == input.CardType);
            //
            return new PagedResultDto<ListSpecialCodeDto>(
                totalCount,
                ObjectMapper.Map<List<SpecialCode>,List<ListSpecialCodeDto>>(entities));
        }
        [Authorize(AccountancyPermissions.SpecialCode.Update)]
        public virtual async Task<SelectSpecialCodeDto> UpdateAsync(Guid id, UpdateSpecialCodeDto input)
        {
            var entity = await _specialCodeRepository.GetAsync(id, x => x.Id == id);
            //
            await _specialCodeManager.CheckUpdateAsync(id, input.Code, entity);
            //
            var mappedEntity = ObjectMapper.Map(input, entity);
            await _specialCodeRepository.UpdateAsync(mappedEntity);
            return ObjectMapper.Map<SpecialCode, SelectSpecialCodeDto>(mappedEntity);
        }
    }
}
