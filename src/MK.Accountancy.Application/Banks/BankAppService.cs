using Microsoft.AspNetCore.Authorization;
using MK.Accountancy.CommonDtos;
using MK.Accountancy.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Banks
{
    [Authorize(AccountancyPermissions.Bank_.Default)]
    public class BankAppService : AccountancyAppService, IBankAppService
    {
        private readonly IBankRepository _bankRepository;
        private readonly BankManager _bankManager;

        public BankAppService(IBankRepository bankRepository, BankManager bankManager)
        {
            _bankRepository = bankRepository;
            _bankManager = bankManager;
        }
        [Authorize(AccountancyPermissions.Bank_.Create)]
        public virtual async Task<SelectBankDto> CreateAsync(CreateBankDto input)
        {
            await _bankManager.CheckCreateAsync(input.Code, input.SpecialCodeOneId, input.SpecialCodeTwoId);
            //
            var entity = ObjectMapper.Map<CreateBankDto, Bank>(input);
            await _bankRepository.InsertAsync(entity);
            return ObjectMapper.Map<Bank, SelectBankDto>(entity);
        }
        [Authorize(AccountancyPermissions.Bank_.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _bankManager.CheckDeleteAsync(id);
            await _bankRepository.DeleteAsync(id);
        }

        public virtual async Task<SelectBankDto> GetAsync(Guid id)
        {
            var entity = await _bankRepository.GetAsync(id, x => x.Id == id, x => x.SpecialCodeOne, x => x.SpecialCodeTwo);
            return ObjectMapper.Map<Bank, SelectBankDto>(entity);
        }

        public virtual async Task<string> GetCodeAsync(CodeParameterDto input)
        {
            return await _bankRepository.GetCodeAsync(x => x.Code, x => x.Active == input.Active);
        }

        public virtual async Task<PagedResultDto<BankListDto>> GetListAsync(BankListParameterDto input)
        {
            var entities = await _bankRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, x => x.Active == input.Active, x => x.Code, x => x.SpecialCodeOne, x => x.SpecialCodeTwo);
            //
            var totalCount = await _bankRepository.CountAsync(x => x.Active == input.Active);
            //
            return new PagedResultDto<BankListDto>(totalCount, ObjectMapper.Map<List<Bank>, List<BankListDto>>(entities));
        }
        [Authorize(AccountancyPermissions.Bank_.Update)]
        public virtual async Task<SelectBankDto> UpdateAsync(Guid id, UpdateBankDto input)
        {
            var entity = await _bankRepository.GetAsync(id, x => x.Id == id);
            //
            await _bankManager.CheckUpdateAsync(id, input.Code,entity, input.SpecialCodeOneId, input.SpecialCodeTwoId);
            //
            var mappedEntity = ObjectMapper.Map(input, entity);
            await _bankRepository.UpdateAsync(mappedEntity);
            return ObjectMapper.Map<Bank, SelectBankDto>(mappedEntity);
        }
    }
}
