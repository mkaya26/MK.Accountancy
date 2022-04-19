using MK.Accountancy.BankAccounts;
using MK.Accountancy.BankDepartments;
using MK.Accountancy.Banks;
using MK.Accountancy.Extensions;
using MK.Accountancy.Safes;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Receipts
{
    public class ReceiptDetailManager : DomainService
    {
        private readonly IBankRepository _bankRepository;
        private readonly ISafeRepository _safeRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IBankDepartmentRepository _bankDepartmentRepository;

        public ReceiptDetailManager(IBankRepository bankRepository, ISafeRepository safeRepository, IBankAccountRepository bankAccountRepository, IBankDepartmentRepository bankDepartmentRepository)
        {
            _bankRepository = bankRepository;
            _safeRepository = safeRepository;
            _bankAccountRepository = bankAccountRepository;
            _bankDepartmentRepository = bankDepartmentRepository;
        }

        public async Task CheckCreateAsync(Guid? chequeBankId, Guid? chequeBankDepartmentId, Guid? safeId, Guid? bankAccountId)
        {
            await _bankRepository.EntityAnyAsync(chequeBankId, f => f.Id == chequeBankId);
            await _bankDepartmentRepository.EntityAnyAsync(chequeBankDepartmentId, f => f.Id == chequeBankDepartmentId);
            await _bankAccountRepository.EntityAnyAsync(bankAccountId, f => f.Id == bankAccountId);
            await _safeRepository.EntityAnyAsync(safeId, f => f.Id == safeId);
        }

        public async Task CheckUpdateAsync(Guid? chequeBankId, Guid? chequeBankDepartmentId, Guid? safeId, Guid? bankAccountId)
        {
            await _bankRepository.EntityAnyAsync(chequeBankId, f => f.Id == chequeBankId);
            await _bankDepartmentRepository.EntityAnyAsync(chequeBankDepartmentId, f => f.Id == chequeBankDepartmentId);
            await _bankAccountRepository.EntityAnyAsync(bankAccountId, f => f.Id == bankAccountId);
            await _safeRepository.EntityAnyAsync(safeId, f => f.Id == safeId);
        }
    }
}
