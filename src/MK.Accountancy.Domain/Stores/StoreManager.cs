using MK.Accountancy.Departments;
using MK.Accountancy.Extensions;
using MK.Accountancy.SpecialCodes;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Stores
{
    public class StoreManager : DomainService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ISpecialCodeRepository _specialCodeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public StoreManager(IStoreRepository storeRepository, ISpecialCodeRepository specialCodeRepository, IDepartmentRepository departmentRepository)
        {
            _storeRepository = storeRepository;
            _specialCodeRepository = specialCodeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task CheckCreateAsync(string code, Guid? specialCodeOneId, Guid? specialCodeTwoId,Guid departmentId)
        {
            await _departmentRepository.EntityAnyAsync(departmentId, x => x.Id == departmentId);
            await _storeRepository.CodeAnyAsync(code, x => x.Code == code && x.DepartmentId == departmentId);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Story);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Story);
        }

        public async Task CheckUpdateAsync(Guid id, string code, Store entity, Guid? specialCodeOneId, Guid? specialCodeTwoId)
        {
            await _storeRepository.CodeAnyAsync(code, x => x.Id != id && x.Code == code && x.DepartmentId == entity.DepartmentId, entity.Code != code);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Story);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Story);
        }

        public async Task CheckDeleteAsync(Guid id)
        {
            await _storeRepository.RelationalEntityAnyAsync(
                x => x.InvoiceDetails.Any(y => y.StoryId == id));
        }
    }
}
