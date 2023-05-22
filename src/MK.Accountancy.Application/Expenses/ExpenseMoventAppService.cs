using MK.Accountancy.Invoices;
using MK.Accountancy.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace MK.Accountancy.Expenses
{
    public class ExpenseMoventAppService : AccountancyAppService, IExpenseMoventAppService
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ExpenseMoventAppService(IInvoiceDetailRepository invoiceDetailRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }
        public async Task<PagedResultDto<ListExpenseMoventDto>> GetListAsync(ExpenseMoventListParameterDto input)
        {
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
            {
                var movents = await _invoiceDetailRepository.GetPagedListAsync(
                    input.SkipCount,
                    input.MaxResultCount,
                    x => x.ExpenseId == input.ExpenseId &&
                    x.Invoice.DepartmentId == input.DepartmentId &&
                    x.Invoice.TermId == input.TermId &&
                    x.Invoice.Active,
                    o => o.Invoice.InvoiceDate,
                    i => i.Invoice,
                    i => i.Expense.Unit);
                //
                var totalCount = await _invoiceDetailRepository.CountAsync(
                    x => x.ExpenseId == input.ExpenseId &&
                    x.Invoice.DepartmentId == input.DepartmentId &&
                    x.Invoice.TermId == input.TermId &&
                    x.Invoice.Active);
                //
                await uow.CompleteAsync();
                //
                var mappedDtos = ObjectMapper.Map<List<InvoiceDetail>, List<ListExpenseMoventDto>>(movents);
                //
                mappedDtos.ForEach(x =>
                {
                    x.DocumentType = L[$"Enum:InvoiceType:{(byte)x.InvoiceType}"];
                    x.InvoiceDetailTypeName = L[$"Enum:InvoiceDetailType:{(byte)x.InvoiceDetailType}"];
                });
                //
                return new PagedResultDto<ListExpenseMoventDto>(totalCount, mappedDtos);
            }
        }

        public Task<SelectInvoiceDetailDto> CreateAsync(InvoiceDetailDto input) => throw new NotImplementedException();

        public Task DeleteAsync(Guid id) => throw new NotImplementedException();

        public Task<SelectInvoiceDetailDto> GetAsync(Guid id) => throw new NotImplementedException();

        public Task<string> GetCodeAsync(InvoiceNumberParameterDto input) => throw new NotImplementedException();

        public Task<SelectInvoiceDetailDto> UpdateAsync(Guid id, InvoiceDetailDto input) => throw new NotImplementedException();
    }
}
