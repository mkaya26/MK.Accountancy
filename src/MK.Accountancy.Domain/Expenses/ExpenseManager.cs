using MK.Accountancy.Extensions;
using MK.Accountancy.SpecialCodes;
using MK.Accountancy.Units;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Expenses
{
    public class ExpenseManager : DomainService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly ISpecialCodeRepository _specialCodeRepository;

        public ExpenseManager(IExpenseRepository expenseRepository, IUnitRepository unitRepository, ISpecialCodeRepository specialCodeRepository)
        {
            _expenseRepository = expenseRepository;
            _unitRepository = unitRepository;
            _specialCodeRepository = specialCodeRepository;
        }

        public async Task CheckCreateAsync(string code, Guid? specialCodeOneId, Guid? specialCodeTwoId, Guid? unitId)
        {
            await _unitRepository.EntityAnyAsync(unitId, x => x.Id == unitId);
            await _expenseRepository.CodeAnyAsync(code, x => x.Code == code);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Expense);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Expense);
        }

        public async Task CheckUpdateAsync(Guid id, string code, Expense entity, Guid? specialCodeOneId, Guid? specialCodeTwoId, Guid? unitId)
        {
            await _expenseRepository.CodeAnyAsync(code, x => x.Id != id && x.Code == code, entity.Code != code);
            await _unitRepository.EntityAnyAsync(unitId, x => x.Id == unitId);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Expense, entity.SpecialCodeOneId != specialCodeOneId);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Expense, entity.SpecialCodeTwoId != specialCodeTwoId);
        }

        public async Task CheckDeleteAsync(Guid id)
        {
            await _expenseRepository.RelationalEntityAnyAsync(
                x => x.InvoiceDetails.Any(y => y.ExpenseId == id));
        }
    }
}
