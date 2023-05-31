using Microsoft.AspNetCore.Authorization;
using MK.Accountancy.CommonDtos;
using MK.Accountancy.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Expenses
{
    [Authorize(AccountancyPermissions.Expense.Default)]
    public class ExpenseAppService : AccountancyAppService, IExpenceAppService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ExpenseManager _expenseManager;

        public ExpenseAppService(IExpenseRepository expenseRepository, ExpenseManager expenseManager)
        {
            _expenseRepository = expenseRepository;
            _expenseManager = expenseManager;
        }
        [Authorize(AccountancyPermissions.Expense.Create)]
        public virtual async Task<SelectExpenseDto> CreateAsync(CreateExpenseDto input)
        {
            await _expenseManager.CheckCreateAsync(input.Code, input.SpecialCodeOneId, input.SpecialCodeTwoId, input.UnitId);
            //
            var entity = ObjectMapper.Map<CreateExpenseDto, Expense>(input);
            await _expenseRepository.InsertAsync(entity);
            return ObjectMapper.Map<Expense, SelectExpenseDto>(entity);
        }
        [Authorize(AccountancyPermissions.Expense.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _expenseManager.CheckDeleteAsync(id);
            //
            await _expenseRepository.DeleteAsync(id);
        }

        public virtual async Task<SelectExpenseDto> GetAsync(Guid id)
        {
            var entity = await _expenseRepository.GetAsync(id, f => f.Id == id, i => i.Unit, i => i.SpecialCodeOne, i => i.SpecialCodeTwo);
            return ObjectMapper.Map<Expense, SelectExpenseDto>(entity);
        }

        public virtual async Task<string> GetCodeAsync(CodeParameterDto input)
        {
            return await _expenseRepository.GetCodeAsync(p => p.Code, f => f.Active == input.Active);
        }

        public virtual async Task<PagedResultDto<ListExpenseDto>> GetListAsync(ExpenseListParameterDto input)
        {
            var entities = await _expenseRepository.GetPagedListAsync(
                                    input.SkipCount,
                                    input.MaxResultCount,
                                    f => f.Active == input.Active,
                                    o => o.Code);
            var totalCount = await _expenseRepository.CountAsync(f => f.Active == input.Active);
            //
            return new PagedResultDto<ListExpenseDto>(totalCount, ObjectMapper.Map<List<Expense>, List<ListExpenseDto>>(entities));
        }
        [Authorize(AccountancyPermissions.Expense.Update)]
        public virtual async Task<SelectExpenseDto> UpdateAsync(Guid id, UpdateExpenseDto input)
        {
            var entity = await _expenseRepository.GetAsync(id, f => f.Id == id);
            //
            await _expenseManager.CheckUpdateAsync(id, input.Code, entity, input.SpecialCodeOneId, input.SpecialCodeTwoId, input.UnitId);
            //
            var mappedEntity = ObjectMapper.Map(input, entity);
            await _expenseRepository.UpdateAsync(mappedEntity);
            return ObjectMapper.Map<Expense, SelectExpenseDto>(mappedEntity);
        }
    }
}
