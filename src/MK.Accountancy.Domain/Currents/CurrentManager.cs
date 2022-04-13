using MK.Accountancy.Extensions;
using MK.Accountancy.Invoices;
using MK.Accountancy.Receipts;
using MK.Accountancy.SpecialCodes;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Currents
{
    public class CurrentManager : DomainService
    {
        private readonly ICurrentRepository _currentRepository;
        private readonly ISpecialCodeRepository _specialCodeRepository;

        public CurrentManager(ICurrentRepository currentRepository, ISpecialCodeRepository specialCodeRepository)
        {
            _currentRepository = currentRepository;
            _specialCodeRepository = specialCodeRepository;
        }

        public async Task CheckCreateAsync(string code, Guid? specialCodeOneId, Guid? specialCodeTwoId)
        {
            await _currentRepository.CodeAnyAsync(code, f => f.Code == code);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Current);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Current);
        }
        public async Task CheckUpdateAsync(Guid id, string code, Current entity, Guid? specialCodeOneId, Guid? specialCodeTwoId)
        {
            await _currentRepository.CodeAnyAsync(code, f => f.Id != id && f.Code == code && entity.Code != code);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Current);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Current);
        }
        public async Task CheckDeleteAsync(Guid id)
        {
            await _currentRepository.RelationalEntityAnyAsync(
                i => i.Invoices.Any(x => x.CurrentId == id) ||
                     i.Receipts.Any(x => x.CurrentId == id));
        }
    }
}
