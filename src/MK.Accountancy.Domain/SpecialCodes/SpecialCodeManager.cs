using MK.Accountancy.Extensions;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.SpecialCodes
{
    public class SpecialCodeManager : DomainService
    {
        private readonly ISpecialCodeRepository _specialCodeRepository;

        public SpecialCodeManager(ISpecialCodeRepository specialCodeRepository)
        {
            _specialCodeRepository = specialCodeRepository;
        }

        public async Task CheckCreateAsync(string code, SpecialCodeType? specialCodeType, CardType? cardType)
        {
            await _specialCodeRepository.CodeAnyAsync(code,x => x.Code == code && x.SpecialCodeType == specialCodeType && x.CardType == cardType);
        }

        public async Task CheckUpdateAsync(Guid id, string code, SpecialCode entity)
        {
            await _specialCodeRepository.CodeAnyAsync(code, x => x.Id != id && x.Code == code && x.SpecialCodeType == entity.SpecialCodeType && x.CardType == entity.CardType, entity.Code != code);
        }

        public async Task CheckDeleteAsync(Guid id)
        {
            await _specialCodeRepository.RelationalEntityAnyAsync(
                x => x.SpecialCodeOneBankAccounts.Any(y => y.SpecialCodeOneId == id) ||
                     x.SpecialCodeTwoBankAccounts.Any(y => y.SpecialCodeTwoId == id) ||
                     x.SpecialCodeOneBanks.Any(y => y.SpecialCodeOneId == id) ||
                     x.SpecialCodeTwoBanks.Any(y => y.SpecialCodeTwoId == id) ||
                     x.SpecialCodeOneBankDepartments.Any(y => y.SpecialCodeOneId == id) ||
                     x.SpecialCodeTwoBankDepartments.Any(y => y.SpecialCodeTwoId == id) ||
                     x.SpecialCodeOneUnits.Any(y => y.SpecialCodeOneId == id) ||
                     x.SpecialCodeTwoUnits.Any(y => y.SpecialCodeTwoId == id) ||
                     x.SpecialCodeOneCurrents.Any(y => y.SpecialCodeOneId == id) ||
                     x.SpecialCodeTwoCurrents.Any(y => y.SpecialCodeTwoId == id) ||
                     x.SpecialCodeOneStores.Any(y => y.SpecialCodeOneId == id) ||
                     x.SpecialCodeTwoStores.Any(y => y.SpecialCodeTwoId == id) ||
                     x.SpecialCodeOneInvoices.Any(y => y.SpecialCodeOneId == id) ||
                     x.SpecialCodeTwoInvoices.Any(y => y.SpecialCodeTwoId == id) ||
                     x.SpecialCodeOneServices.Any(y => y.SpecialCodeOneId == id) ||
                     x.SpecialCodeTwoServices.Any(y => y.SpecialCodeTwoId == id) ||
                     x.SpecialCodeOneSafes.Any(y => y.SpecialCodeOneId == id) ||
                     x.SpecialCodeTwoSafes.Any(y => y.SpecialCodeTwoId == id) ||
                     x.SpecialCodeOneReceipts.Any(y => y.SpecialCodeOneId == id) ||
                     x.SpecialCodeTwoReceipts.Any(y => y.SpecialCodeTwoId == id) ||
                     x.SpecialCodeOneStocks.Any(y => y.SpecialCodeOneId == id) ||
                     x.SpecialCodeTwoStocks.Any(y => y.SpecialCodeTwoId == id) ||
                     x.SpecialCodeOneExpenses.Any(y => y.SpecialCodeOneId == id) ||
                     x.SpecialCodeTwoExpenses.Any(y => y.SpecialCodeTwoId == id)
                );
        }
    }
}
