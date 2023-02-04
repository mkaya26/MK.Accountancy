//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Threading.Tasks;
//using Volo.Abp.Application.Dtos;
//using Volo.Abp.Domain.Repositories;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace MK.Accountancy.Safes
{
    public class SafeAppService : AccountancyAppService, ISafeAppService
    {
        private readonly ISafeRepository _safeRepository;
        private readonly SafeManager _safeManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SafeAppService(ISafeRepository safeRepository, SafeManager safeManager, IUnitOfWorkManager unitOfWorkManager)
        {
            _safeRepository = safeRepository;
            _safeManager = safeManager;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<SelectSafeDto> CreateAsync(CreateSafeDto input)
        {
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
            {
                await _safeManager.CheckCreateAsync(input.Code, input.SpecialCodeOneId, input.SpecialCodeTwoId, input.DepartmentId);
                //
                await uow.CompleteAsync();
            }
            //
            var entity = ObjectMapper.Map<CreateSafeDto, Safe>(input);
            await _safeRepository.InsertAsync(entity);
            return ObjectMapper.Map<Safe, SelectSafeDto>(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _safeManager.CheckDeleteAsync(id);
            //
            await _safeRepository.DeleteAsync(id);
        }

        public virtual async Task<SelectSafeDto> GetAsync(Guid id)
        {
            var entity = await _safeRepository.GetAsync(id, f => f.Id == id, i => i.SpecialCodeOne, i => i.SpecialCodeTwo);
            return ObjectMapper.Map<Safe, SelectSafeDto>(entity);
        }

        public virtual async Task<string> GetCodeAsync(SafeCodeParameterDto input)
        {
            return await _safeRepository.GetCodeAsync(p => p.Code, f => f.Active == input.Active && f.DepartmentId == input.DepartmentId);
        }

        public async Task<PagedResultDto<ListSafeDto>> GetListAsync(SafeListParameterDto input)
        {
            var entites = await _safeRepository.GetPagedListAsync(
                                                    input.SkipCount,
                                                    input.MaxResultCount,
                                   f => f.Active == input.Active &&
                                   f.DepartmentId == input.DepartmentId,
                                                    o => o.Code,
                                   i => i.SpecialCodeOne,
                                   i => i.SpecialCodeTwo,
                                   i => i.ReceiptDetails);
            //
            int totalCount;
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
            {
                 totalCount = await _safeRepository.CountAsync(f => f.Active == input.Active && f.DepartmentId == input.DepartmentId);
                //
                await uow.CompleteAsync();
            }
            //
            return new PagedResultDto<ListSafeDto>(totalCount, ObjectMapper.Map<List<Safe>, List<ListSafeDto>>(entites));
        }

        public virtual async Task<SelectSafeDto> UpdateAsync(Guid id, UpdateSafeDto input)
        {
            var entity = await _safeRepository.GetAsync(id, f => f.Id == id);
            //
            await _safeManager.CheckUpdateAsync(id, input.Code, entity, input.SpecialCodeOneId, input.SpecialCodeTwoId);
            //
            var mappedEntity = ObjectMapper.Map(input,entity);
            await _safeRepository.UpdateAsync(mappedEntity);
            return ObjectMapper.Map<Safe, SelectSafeDto>(mappedEntity);
        }
    }
}
