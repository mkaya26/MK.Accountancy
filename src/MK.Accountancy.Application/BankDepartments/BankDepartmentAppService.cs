using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.BankDepartments
{
    public class BankDepartmentAppService : AccountancyAppService, IBankDepartmentAppService
    {
        private readonly IBankDepartmentRepository _bankDepartmentRepository;
        private readonly BankDepartmentManager _bankDepartmentManager;

        public BankDepartmentAppService(IBankDepartmentRepository bankDepartmentRepository, BankDepartmentManager bankDepartmentManager)
        {
            _bankDepartmentRepository = bankDepartmentRepository;
            _bankDepartmentManager = bankDepartmentManager;
        }

        public virtual async Task<SelectBankDepartmentDto> CreateAsync(CreateBankDepartmentDto input)
        {
            await _bankDepartmentManager.CheckCreateAsync(input.Code, input.BankId, input.SpecialCodeOneId, input.SpecialCodeTwoId);
            //
            var entity = ObjectMapper.Map<CreateBankDepartmentDto, BankDepartment>(input);
            await _bankDepartmentRepository.InsertAsync(entity);
            return ObjectMapper.Map<BankDepartment, SelectBankDepartmentDto>(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _bankDepartmentManager.CheckDeleteAsync(id);
            //
            await _bankDepartmentRepository.DeleteAsync(id);
        }

        public virtual async Task<SelectBankDepartmentDto> GetAsync(Guid id)
        {
            var entity = await _bankDepartmentRepository.GetAsync(id, x => x.Id == id, x => x.Bank, x => x.SpecialCodeOne, x => x.SpecialCodeTwo);
            return ObjectMapper.Map<BankDepartment, SelectBankDepartmentDto>(entity);
        }

        public virtual async Task<string> GetCodeAsync(BankDepartmentCodeParameterDto input)
        {
            return await _bankDepartmentRepository.GetCodeAsync(x => x.Code, x => x.BankId == input.BankId && x.Active == input.Active);
        }

        public virtual async Task<PagedResultDto<ListBankDepartmentDto>> GetListAsync(BankDepartmentListParameterDto input)
        {
            var entities = await _bankDepartmentRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, x => x.BankId == input.BankId && x.Active == input.Active, x => x.Code, x => x.Bank, x => x.SpecialCodeOne, x => x.SpecialCodeTwo);
            //
            var totalCount = await _bankDepartmentRepository.CountAsync(x => x.BankId == input.BankId && x.Active == input.Active);
            //
            return new PagedResultDto<ListBankDepartmentDto>(totalCount, ObjectMapper.Map<List<BankDepartment>, List<ListBankDepartmentDto>>(entities));
        }

        public virtual async Task<SelectBankDepartmentDto> UpdateAsync(Guid id, UpdateBankDepartmentDto input)
        {
            var entity = await _bankDepartmentRepository.GetAsync(id, x => x.Id == id);
            //
            await _bankDepartmentManager.CheckUpdateAsync(id, input.Code, entity, input.SpecialCodeOneId, input.SpecialCodeTwoId);
            //
            var mappedEntity = ObjectMapper.Map(input, entity);
            await _bankDepartmentRepository.UpdateAsync(mappedEntity);
            return ObjectMapper.Map<BankDepartment, SelectBankDepartmentDto>(mappedEntity);
        }
    }
}
