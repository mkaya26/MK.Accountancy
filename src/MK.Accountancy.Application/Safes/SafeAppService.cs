﻿using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Localization;
using MK.Accountancy.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace MK.Accountancy.Safes
{
    [Authorize(AccountancyPermissions.Safe.Default)]
    public class SafeAppService : AccountancyAppService, ISafeAppService
    {
        private readonly ISafeRepository _safeRepository;
        private readonly SafeManager _safeManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IStringLocalizer<AccountancyResource> _localizer;
        public SafeAppService(ISafeRepository safeRepository, SafeManager safeManager, IUnitOfWorkManager unitOfWorkManager, IStringLocalizer<AccountancyResource> localizer)
        {
            _safeRepository = safeRepository;
            _safeManager = safeManager;
            _unitOfWorkManager = unitOfWorkManager;
            _localizer = localizer;
        }
        [Authorize(AccountancyPermissions.Safe.Create)]
        public async Task<SelectSafeDto> CreateAsync(CreateSafeDto input)
        {
            var validator = new CreateSafeDtoValidator(_localizer);
            var validationResult = await validator.ValidateAsync(input);
            //
            if (!validationResult.IsValid)
            {
                string validationMessage = string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new UserFriendlyException(validationMessage);
            }
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
            {
                //
                await _safeManager.CheckCreateAsync(input.Code, input.SpecialCodeOneId, input.SpecialCodeTwoId, input.DepartmentId);
                //
                var entity = ObjectMapper.Map<CreateSafeDto, Safe>(input);
                await _safeRepository.InsertAsync(entity);
                //
                await uow.CompleteAsync();
                //
                return ObjectMapper.Map<Safe, SelectSafeDto>(entity);
            }
        }

        [Authorize(AccountancyPermissions.Safe.Delete)]
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
            return await _safeRepository.GetCodeAsync(p => p.Code, f =>  f.DepartmentId == input.DepartmentId);
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
        [Authorize(AccountancyPermissions.Safe.Update)]
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
