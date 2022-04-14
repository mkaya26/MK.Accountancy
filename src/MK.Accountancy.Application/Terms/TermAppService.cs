using MK.Accountancy.CommonDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Terms
{
    public class TermAppService : AccountancyAppService, ITermAppService
    {
        private readonly ITermRepository _termRepository;
        private readonly TermManager _termManager;

        public TermAppService(ITermRepository termRepository, TermManager termManager)
        {
            _termRepository = termRepository;
            _termManager = termManager;
        }

        public virtual async Task<SelectTermDto> CreateAsync(CreateTermDto input)
        {
            await _termManager.CheckCreateAsync(input.Code);
            //
            var entity = ObjectMapper.Map<CreateTermDto, Term>(input);
            await _termRepository.InsertAsync(entity);
            return ObjectMapper.Map<Term, SelectTermDto>(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _termManager.CheckDeleteAsync(id);
            //
            await _termRepository.DeleteAsync(id);
        }

        public virtual async Task<SelectTermDto> GetAsync(Guid id)
        {
            var entity = await _termRepository.GetAsync(id, f => f.Id == id);
            return ObjectMapper.Map<Term, SelectTermDto>(entity);
        }

        public virtual async Task<string> GetCodeAsync(CodeParameterDto input)
        {
            return await _termRepository.GetCodeAsync(p => p.Code, f => f.Active);
        }

        public virtual async Task<PagedResultDto<ListTermDto>> GetListAsync(TermListParameterDto input)
        {
            var entities = await _termRepository.GetPagedListAsync(
                                             input.SkipCount,
                                             input.MaxResultCount,
                                             f => f.Active == input.Active,
                                             o => o.Code);
            //
            var totalCount = await _termRepository.CountAsync(f => f.Active);
            //
            var mappedEntities = ObjectMapper.Map<List<Term>, List<ListTermDto>>(entities);
            //
            return new PagedResultDto<ListTermDto>(totalCount, mappedEntities);
        }

        public virtual async Task<SelectTermDto> UpdateAsync(Guid id, UpdateTermDto input)
        {
            var entity = await _termRepository.GetAsync(id, f => f.Id == id);
            //
            await _termManager.CheckUpdateAsync(id, input.Code, entity);
            //
            var mappedEntity = ObjectMapper.Map(input, entity);
            await _termRepository.UpdateAsync(mappedEntity);
            return ObjectMapper.Map<Term, SelectTermDto>(mappedEntity);
        }
    }
}
