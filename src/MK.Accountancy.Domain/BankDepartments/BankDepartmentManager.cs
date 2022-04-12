using MK.Accountancy.Banks;
using MK.Accountancy.Extensions;
using MK.Accountancy.SpecialCodes;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.BankDepartments
{
    public class BankDepartmentManager : DomainService
    {
        private readonly IBankDepartmentRepository _bankDepartmentRepository;
        private readonly IBankRepository _bankRepository;
        private readonly ISpecialCodeRepository _specialCodeRepository;

        public BankDepartmentManager(IBankDepartmentRepository bankDepartmentRepository, IBankRepository bankRepository, ISpecialCodeRepository specialCodeRepository)
        {
            _bankDepartmentRepository = bankDepartmentRepository;
            _bankRepository = bankRepository;
            _specialCodeRepository = specialCodeRepository;
        }

        public async Task CheckCreateAsync(string code,Guid? bankId, Guid? specialCodeOneId, Guid? specialCodeTwoId)
        {
            await _bankRepository.EntityAnyAsync(bankId, x => x.Id == bankId);
            await _bankDepartmentRepository.CodeAnyAsync(code, x => x.Code == code && x.BankId == bankId);
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.BankDepartment);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.BankDepartment);
        }

        public async Task CheckUpdateAsync(Guid id, string code, BankDepartment entity, Guid? specialCodeOneId, Guid? specialCodeTwoId)
        {
            await _bankDepartmentRepository.CodeAnyAsync(code, x => x.Id != id && x.Code == code && x.BankId == entity.BankId, entity.Code != code);
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.BankDepartment, entity.SpecialCodeOneId != specialCodeOneId);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.BankDepartment, entity.SpecialCodeTwoId != specialCodeTwoId);
        }

        public async Task CheckDeleteAsync(Guid id)
        {
            await _bankDepartmentRepository.RelationalEntityAnyAsync(
                x => x.BankAccounts.Any(y => y.BankDepartmentId == id) ||
                     x.ChequeReceiptDetails.Any(y => y.ChequeBankDepartmentId == id));
        }
    }
}
