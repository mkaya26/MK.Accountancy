using MK.Accountancy.CommonDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Banks
{
    public class BankAppService : AccountancyAppService, IBankAppService
    {
        private readonly IBankRepository _bankRepository;

        public BankAppService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public virtual async Task<SelectBankDto> CreateAsync(CreateBankDto input)
        {
            var entity = ObjectMapper.Map<CreateBankDto, Bank>(input);
            await _bankRepository.InsertAsync(entity);
            return ObjectMapper.Map<Bank, SelectBankDto>(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
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

        public virtual async Task<SelectBankDto> UpdateAsync(Guid id, UpdateBankDto input)
        {
            var entity = await _bankRepository.GetAsync(id, x => x.Id == id);
            var mappedEntity = ObjectMapper.Map(input, entity);
            await _bankRepository.UpdateAsync(mappedEntity);
            return ObjectMapper.Map<Bank, SelectBankDto>(mappedEntity);
        }
    }
}
