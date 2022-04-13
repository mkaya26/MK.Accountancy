using MK.Accountancy.BankDepartments;
using MK.Accountancy.Departments;
using MK.Accountancy.Extensions;
using MK.Accountancy.SpecialCodes;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.BankAccounts
{
    public class BankAccountManager : DomainService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IBankDepartmentRepository _bankDepartmentRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ISpecialCodeRepository _specialCodeRepository;

        public BankAccountManager(IDepartmentRepository departmentRepository, IBankDepartmentRepository bankDepartmentRepository, IBankAccountRepository bankAccountRepository, ISpecialCodeRepository specialCodeRepository)
        {
            _departmentRepository = departmentRepository;
            _bankDepartmentRepository = bankDepartmentRepository;
            _bankAccountRepository = bankAccountRepository;
            _specialCodeRepository = specialCodeRepository;
        }

        public async Task CheckCreateAsync(string code, Guid? bankDepartmentId, Guid? departmentId, Guid? specialCodeOneId, Guid? specialCodeTwoId)
        {
            await _departmentRepository.EntityAnyAsync(departmentId, x => x.Id == departmentId);
            await _bankAccountRepository.CodeAnyAsync(code, x => x.Code == code && x.DepartmentId == departmentId);
            await _bankDepartmentRepository.EntityAnyAsync(bankDepartmentId, x => x.Id == bankDepartmentId);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.BankAccount);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.BankAccount);
        }

        public async Task CheckUpdateAsync(Guid id, string code, BankAccount entity, Guid? bankDepartmentId, Guid? specialCodeOneId, Guid? specialCodeTwoId)
        {
            await _bankAccountRepository.CodeAnyAsync(code, x => x.Id != id && x.Code == code && x.BankDepartmentId == entity.DepartmentId, entity.Code != code);
            //
            await _bankDepartmentRepository.EntityAnyAsync(bankDepartmentId, x => x.Id == bankDepartmentId, entity.BankDepartmentId != bankDepartmentId);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.BankAccount, entity.SpecialCodeOneId != specialCodeOneId);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.BankAccount, entity.SpecialCodeTwoId != specialCodeTwoId);
        }

        public async Task CheckDeleteAsync(Guid id)
        {
            await _bankAccountRepository.RelationalEntityAnyAsync(
                x => x.Receipts.Any(y => y.BankAccountId == id) ||
                     x.ReceiptDetails.Any(y => y.BankAccountId == id));
        }
    }
}
