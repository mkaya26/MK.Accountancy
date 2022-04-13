using MK.Accountancy.Extensions;
using MK.Accountancy.SpecialCodes;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Units
{
    public class UnitManager : DomainService
    {
        private readonly IUnitRepository _unitRepository;
        private readonly ISpecialCodeRepository _specialCodeRepository;

        public UnitManager(IUnitRepository unitRepository, ISpecialCodeRepository specialCodeRepository)
        {
            _unitRepository = unitRepository;
            _specialCodeRepository = specialCodeRepository;
        }

        public async Task CheckCreateAsync(string code, Guid? specialCodeOneId, Guid? specialCodeTwoId)
        {
            await _unitRepository.CodeAnyAsync(code, x => x.Code == code);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Unit);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Unit);
        }

        public async Task CheckUpdateAsync(Guid id, string code, Unit entity, Guid? specialCodeOneId, Guid? specialCodeTwoId)
        {
            await _unitRepository.CodeAnyAsync(code, x => x.Id != id && x.Code == code, entity.Code != code);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Unit);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Unit);
        }

        public async Task CheckDeleteAsync(Guid id)
        {
            await _unitRepository.RelationalEntityAnyAsync(
                x => x.Services.Any(y => y.UnitId == id) ||
                     x.Expenses.Any(y => y.UnitId == id) ||
                     x.Stocks.Any(y => y.UnitId == id));
        }
    }
}
