using MK.Accountancy.BankAccounts;
using MK.Accountancy.Currents;
using MK.Accountancy.Departments;
using MK.Accountancy.Extensions;
using MK.Accountancy.Safes;
using MK.Accountancy.SpecialCodes;
using MK.Accountancy.Terms;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Receipts
{
    public class ReceiptManager : DomainService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly ICurrentRepository _currentRepository;
        private readonly ISafeRepository _safeRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ISpecialCodeRepository _specialCodeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITermRepository _termRepository;

        public ReceiptManager(IReceiptRepository receiptRepository, ICurrentRepository currentRepository, ISafeRepository safeRepository, IBankAccountRepository bankAccountRepository, ISpecialCodeRepository specialCodeRepository, IDepartmentRepository departmentRepository, ITermRepository termRepository)
        {
            _receiptRepository = receiptRepository;
            _currentRepository = currentRepository;
            _safeRepository = safeRepository;
            _bankAccountRepository = bankAccountRepository;
            _specialCodeRepository = specialCodeRepository;
            _departmentRepository = departmentRepository;
            _termRepository = termRepository;
        }

        public async Task CheckCreateAsync(string receiptNumber,ReceiptType receiptType, Guid? currentId, Guid? specialCodeOneId, Guid? specialCodeTwoId, Guid? departmentId, Guid? termId,Guid? safeId,Guid? bankAccountId)
        {
            await _departmentRepository.EntityAnyAsync(departmentId, f => f.Id == departmentId);
            await _termRepository.EntityAnyAsync(termId, f => f.Id == termId);
            await _receiptRepository.CodeAnyAsync(receiptNumber,
                                        f => f.ReceiptNumber == receiptNumber &&
                                             f.ReceiptType == receiptType &&
                                             f.DepartmentId == departmentId &&
                                             f.TermId == termId);
            await _currentRepository.EntityAnyAsync(currentId, f => f.Id == currentId);
            await _safeRepository.EntityAnyAsync(safeId, f => f.Id == safeId);
            await _bankAccountRepository.EntityAnyAsync(bankAccountId, f => f.Id == bankAccountId);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Receipt);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Receipt);
        }

        public async Task CheckUpdateAsync(Guid id, string receiptNumber, Receipt entity, Guid? specialCodeOneId, Guid? specialCodeTwoId, Guid? currentId, Guid? safeId, Guid? bankAccountId)
        {
            await _receiptRepository.CodeAnyAsync(receiptNumber,
                                         f => f.Id != id &&
                                              f.ReceiptNumber == receiptNumber &&
                                              f.DepartmentId == entity.DepartmentId &&
                                              f.TermId == entity.TermId,
                                         entity.ReceiptNumber != receiptNumber);
            await _currentRepository.EntityAnyAsync(currentId, f => f.Id == currentId);
            await _safeRepository.EntityAnyAsync(safeId, f => f.Id == safeId);
            await _bankAccountRepository.EntityAnyAsync(bankAccountId, f => f.Id == bankAccountId);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId,                SpecialCodeType.SpecialCodeOne,
                                                        CardType.Receipt,
                                                        entity.SpecialCodeOneId != specialCodeOneId);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId,
                                                        SpecialCodeType.SpecialCodeTwo,
                                                        CardType.Receipt,
                                                        entity.SpecialCodeTwoId != specialCodeTwoId);
        }
    }
}
