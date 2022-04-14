using MK.Accountancy.Currents;
using MK.Accountancy.Departments;
using MK.Accountancy.Extensions;
using MK.Accountancy.SpecialCodes;
using MK.Accountancy.Terms;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Invoices
{
    public class InvoiceManager : DomainService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICurrentRepository _currentRepository;
        private readonly ISpecialCodeRepository _specialCodeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITermRepository _termRepository;

        public InvoiceManager(IInvoiceRepository invoiceRepository, ICurrentRepository currentRepository, ISpecialCodeRepository specialCodeRepository, IDepartmentRepository departmentRepository, ITermRepository termRepository)
        {
            _invoiceRepository = invoiceRepository;
            _currentRepository = currentRepository;
            _specialCodeRepository = specialCodeRepository;
            _departmentRepository = departmentRepository;
            _termRepository = termRepository;
        }

        public async Task CheckCreateAsync(string invoiceNumber, Guid? currentId, Guid? specialCodeOneId, Guid? specialCodeTwoId, Guid? departmentId, Guid? termId)
        {
            await _departmentRepository.EntityAnyAsync(departmentId, f => f.Id == departmentId);
            await _termRepository.EntityAnyAsync(termId, f => f.Id == termId);
            await _invoiceRepository.CodeAnyAsync(invoiceNumber, 
                                        f => f.InvoiceNumber == invoiceNumber && 
                                             f.DepartmentId == departmentId && 
                                             f.TermId == termId);
            await _currentRepository.EntityAnyAsync(currentId, f => f.Id == currentId);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId, SpecialCodeType.SpecialCodeOne, CardType.Invoice);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId, SpecialCodeType.SpecialCodeTwo, CardType.Invoice);
        }

        public async Task CheckUpdateAsync(Guid id, string invoiceNumber, Invoice entity, Guid? specialCodeOneId, Guid? specialCodeTwoId,Guid? currentId)
        {
            await _invoiceRepository.CodeAnyAsync(invoiceNumber,
                                         f => f.Id != id &&
                                              f.InvoiceNumber == invoiceNumber &&
                                              f.DepartmentId == entity.DepartmentId &&
                                              f.TermId == entity.TermId,
                                         entity.InvoiceNumber != invoiceNumber);
            await _currentRepository.EntityAnyAsync(currentId, f => f.Id == currentId);
            //
            await _specialCodeRepository.EntityAnyAsync(specialCodeOneId,                                                                     SpecialCodeType.SpecialCodeOne, 
                                                        CardType.Invoice, 
                                                        entity.SpecialCodeOneId != specialCodeOneId);
            await _specialCodeRepository.EntityAnyAsync(specialCodeTwoId,                   
                                                        SpecialCodeType.SpecialCodeTwo, 
                                                        CardType.Invoice, 
                                                        entity.SpecialCodeTwoId != specialCodeTwoId);
        }
    }
}
