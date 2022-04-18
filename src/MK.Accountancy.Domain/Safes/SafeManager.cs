using MK.Accountancy.Departments;
using MK.Accountancy.Extensions;
using MK.Accountancy.SpecialCodes;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Safes
{
    public class SafeManager : DomainService
    {
        private readonly ISafeRepository _safesRepository;
        private readonly ISpecialCodeRepository _specialCodeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public SafeManager(ISafeRepository safesRepository, ISpecialCodeRepository specialCodeRepository, IDepartmentRepository departmentRepository)
        {
            _safesRepository = safesRepository;
            _specialCodeRepository = specialCodeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task CheckCreateAsync(string code, Guid? specialCodeOneId, Guid? specialCodeTwoId,Guid? departmentId)
        {
            await _departmentRepository.EntityAnyAsync(departmentId, x => x.Id == departmentId);
            await _safesRepository.CodeAnyAsync(code, x => x.Code == code && x.DepartmentId == departmentId);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Safe);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Safe);
        }

        public async Task CheckUpdateAsync(Guid id, string code, Safe entity, Guid? specialCodeOneId, Guid? specialCodeTwoId)
        {
            await _safesRepository.CodeAnyAsync(code, x => x.Id != id && x.Code == code && x.DepartmentId == entity.DepartmentId, entity.Code != code);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Safe, entity.SpecialCodeOneId != specialCodeOneId);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Safe, entity.SpecialCodeTwoId != specialCodeTwoId);
        }

        public async Task CheckDeleteAsync(Guid id)
        {
            await _safesRepository.RelationalEntityAnyAsync(
                x => x.Receipts.Any(y => y.SafeId == id) ||
                     x.ReceiptDetails.Any(y => y.SafeId == id));
        }
    }
}
