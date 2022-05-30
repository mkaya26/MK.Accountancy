using MK.Accountancy.Extensions;
using MK.Accountancy.SpecialCodes;
using MK.Accountancy.Units;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Stocks
{
    public class StockManager : DomainService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly ISpecialCodeRepository _specialCodeRepository;

        public StockManager(IStockRepository stockRepository, IUnitRepository unitRepository, ISpecialCodeRepository specialCodeRepository)
        {
            _stockRepository = stockRepository;
            _unitRepository = unitRepository;
            _specialCodeRepository = specialCodeRepository;
        }

        public async Task CheckCreateAsync(string code, Guid? specialCodeOneId, Guid? specialCodeTwoId, Guid? unitId)
        {
            await _unitRepository.EntityAnyAsync(unitId, x => x.Id == unitId);
            await _stockRepository.CodeAnyAsync(code, x => x.Code == code);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Stock);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Stock);
        }

        public async Task CheckUpdateAsync(Guid id, string code, Stock entity, Guid? specialCodeOneId, Guid? specialCodeTwoId, Guid? unitId)
        {
            await _stockRepository.CodeAnyAsync(code, x => x.Id != id && x.Code == code, entity.Code != code);
            await _unitRepository.EntityAnyAsync(unitId, x => x.Id == unitId);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Stock, entity.SpecialCodeOneId != specialCodeOneId);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Stock, entity.SpecialCodeTwoId != specialCodeTwoId);
        }

        public async Task CheckDeleteAsync(Guid id)
        {
            await _stockRepository.RelationalEntityAnyAsync(
                x => x.InvoiceDetails.Any(y => y.StockId == id));
        }
    }
}
