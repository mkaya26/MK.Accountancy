using MK.Accountancy.Extensions;
using MK.Accountancy.SpecialCodes;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Banks
{
    public class BankManager : DomainService
    {
        private readonly IBankRepository _bankRepository;
        private readonly ISpecialCodeRepository _specialCodeRepository;

        public BankManager(IBankRepository bankRepository, ISpecialCodeRepository specialCodeRepository)
        {
            _bankRepository = bankRepository;
            _specialCodeRepository = specialCodeRepository;
        }

        public async Task CheckCreateAsync(string code,Guid? specialCodeOneId,Guid? specialCodeTwoId) 
        {
            await _bankRepository.CodeAnyAsync(code, x => x.Code == code);
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Bank);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Bank);
        }

        public async Task CheckUpdateAsync(Guid id,string code,Bank entity,Guid? specialCodeOneId,Guid? specialCodeTwoId)
        {
            await _bankRepository.CodeAnyAsync(code, x => x.Id != id &&
                                                          x.Code == code &&
                                                          entity.Code != code);
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Bank, entity.SpecialCodeOneId != specialCodeOneId);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Bank, entity.SpecialCodeTwoId != specialCodeTwoId);
        }

        public async Task CheckDeleteAsync(Guid id)
        {
            await _bankRepository.RelationalEntityAnyAsync(
                x => x.BankDepartments.Any(y => y.BankId == id) ||
                     x.ChequeReceiptDetails.Any(y => y.ChequeBankId == id));
        }
    }
}
