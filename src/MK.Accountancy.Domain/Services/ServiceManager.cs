using MK.Accountancy.Extensions;
using MK.Accountancy.SpecialCodes;
using MK.Accountancy.Units;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Services
{
    public class ServiceManager : DomainService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ISpecialCodeRepository _specialCodeRepository;
        private readonly IUnitRepository _unitRepository;

        public ServiceManager(IServiceRepository serviceRepository, ISpecialCodeRepository specialCodeRepository, IUnitRepository unitRepository)
        {
            _serviceRepository = serviceRepository;
            _specialCodeRepository = specialCodeRepository;
            _unitRepository = unitRepository;
        }

        public async Task CheckCreateAsync(string code, Guid? specialCodeOneId, Guid? specialCodeTwoId, Guid? unitId)
        {
            await _unitRepository.EntityAnyAsync(unitId, x => x.Id == unitId);
            await _serviceRepository.CodeAnyAsync(code, x => x.Code == code);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Service);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Service);
        }

        public async Task CheckUpdateAsync(Guid id, string code, Service entity, Guid? specialCodeOneId, Guid? specialCodeTwoId,Guid? unitId)
        {
            await _serviceRepository.CodeAnyAsync(code, x => x.Id != id && x.Code == code, entity.Code != code);
            await _unitRepository.EntityAnyAsync(unitId, x => x.Id == unitId);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Service, entity.SpecialCodeOneId != specialCodeOneId);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Service, entity.SpecialCodeTwoId != specialCodeTwoId);
        }

        public async Task CheckDeleteAsync(Guid id)
        {
            await _serviceRepository.RelationalEntityAnyAsync(
                x => x.InvoiceDetails.Any(y => y.ServiceId == id));
        }
    }
}
