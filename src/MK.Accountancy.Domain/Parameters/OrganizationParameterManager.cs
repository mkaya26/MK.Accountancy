using MK.Accountancy.Departments;
using MK.Accountancy.Extensions;
using MK.Accountancy.Stores;
using MK.Accountancy.Terms;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Parameters
{
    public class OrganizationParameterManager : DomainService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly ITermRepository _termRepository;

        public OrganizationParameterManager(IDepartmentRepository departmentRepository, IStoreRepository storeRepository, ITermRepository termRepository)
        {
            _departmentRepository = departmentRepository;
            _storeRepository = storeRepository;
            _termRepository = termRepository;
        }

        public async Task CheckCreateAsync(Guid? termId, Guid? departmentId, Guid? storeId)
        {
            await _departmentRepository.EntityAnyAsync(departmentId, f => f.Id == departmentId);
            await _storeRepository.EntityAnyAsync(storeId, f => f.Id == storeId);
            await _termRepository.EntityAnyAsync(termId, f => f.Id == termId);
        }

        public async Task CheckUpdateAsync(Guid? termId, Guid? departmentId, Guid? storeId)
        {
            await _departmentRepository.EntityAnyAsync(departmentId, f => f.Id == departmentId);
            await _storeRepository.EntityAnyAsync(storeId, f => f.Id == storeId);
            await _termRepository.EntityAnyAsync(termId, f => f.Id == termId);
        }
    }
}
