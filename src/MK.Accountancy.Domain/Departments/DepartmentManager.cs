using MK.Accountancy.Extensions;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Departments
{
    public class DepartmentManager : DomainService
    {
        private readonly IDepartmentRepository _departmentsRepository;

        public DepartmentManager(IDepartmentRepository departmentsRepository)
        {
            _departmentsRepository = departmentsRepository;
        }

        public async Task CheckCreateAsync(string code)
        {
            await _departmentsRepository.CodeAnyAsync(code, x => x.Code == code);
        }

        public async Task CheckUpdateAsync(Guid id, string code, Department entity)
        {
            await _departmentsRepository.CodeAnyAsync(code, x => x.Id != id && x.Code == code, entity.Code != code);
        }

        public async Task CheckDeleteAsync(Guid id)
        {
            await _departmentsRepository.RelationalEntityAnyAsync(
                x => x.Invoices.Any(y => y.DepartmentId == id) ||
                     x.Receipts.Any(y => y.DepartmentId == id) || 
                     x.BankAccounts.Any(y => y.DepartmentId == id) ||
                     x.Stores.Any(y => y.DepartmentId == id) ||
                     x.Safes.Any(y => y.DepartmentId == id) ||
                     x.OrganizationParameters.Any(y => y.DepartmentId == id));
        }
    }
}
