using MK.Accountancy.Receipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.BankAccounts
{
    public class BankAccountAppService : AccountancyAppService, IBankAccountAppService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly BankAccountManager _bankAccountManager;

        public BankAccountAppService(IBankAccountRepository bankAccountRepository, BankAccountManager bankAccountManager)
        {
            _bankAccountRepository = bankAccountRepository;
            _bankAccountManager = bankAccountManager;
        }

        public virtual async Task<SelectBankAccountDto> CreateAsync(CreateBankAccountDto input)
        {
            await _bankAccountManager.CheckCreateAsync(input.Code, input.BankDepartmentId, input.DepartmentId, input.SpecialCodeOneId, input.SpecialCodeTwoId);
            //
            var entity = ObjectMapper.Map<CreateBankAccountDto, BankAccount>(input);
            await _bankAccountRepository.InsertAsync(entity);
            return ObjectMapper.Map<BankAccount,SelectBankAccountDto>(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _bankAccountManager.CheckDeleteAsync(id);
            //
            await _bankAccountRepository.DeleteAsync(id);
        }

        public virtual async Task<SelectBankAccountDto> GetAsync(Guid id)
        {
            var entity = await _bankAccountRepository.GetAsync(id, x => x.Id == id, i => i.BankDepartment, i => i.BankDepartment.Bank, i => i.SpecialCodeOne, i => i.SpecialCodeTwo);
            //
            var mappedDto = ObjectMapper.Map<BankAccount, SelectBankAccountDto>(entity);
            mappedDto.BankAccountTypeName = L[$"Enum:BankAccountType:{(byte)mappedDto.BankAccountType}"];
            return mappedDto;
        }

        public virtual async Task<string> GetCodeAsync(BankAccountCodeParameterDto input)
        {
            return await _bankAccountRepository.GetCodeAsync(x => x.Code, x => x.DepartmentId == input.DepartmentId && x.Active == input.Active);
        }

        public virtual async Task<PagedResultDto<ListBankAccountDto>> GetListAsync(BankAccountListParameterDto input)
        {
            var entities = await _bankAccountRepository.GetPagedListAsync         (input.SkipCount,input.MaxResultCount, 
                x=> input.BankAccountType == null ? 
                    x.DepartmentId == input.DepartmentId &&
                    x.Active == input.Active :
                    x.BankAccountType == input.BankAccountType &&
                    x.DepartmentId == input.DepartmentId &&
                    x.Active == input.Active,
                x => x.Code,
                i => i.BankDepartment, 
                i => i.BankDepartment.Bank, 
                i => i.SpecialCodeOne, 
                i => i.SpecialCodeTwo,
                i => i.ReceiptDetails);
            //
            var totalCount = await _bankAccountRepository.CountAsync(
                x => input.BankAccountType == null ?
                    x.BankDepartmentId == input.DepartmentId &&
                    x.Active == input.Active :
                    x.BankAccountType == input.BankAccountType &&
                    x.BankDepartmentId == input.DepartmentId &&
                    x.Active == input.Active);
            //
            var mappedDto = ObjectMapper.Map<List<BankAccount>, List<ListBankAccountDto>>(entities);
            //
            mappedDto.ForEach(x =>
                {
                    x.BankAccountTypeName = L[$"Enum:BankAccountType:{(byte)x.BankAccountType}"];
                    x.Debt = x.ReceiptDetails.Where(
                                y => y.DocumentStatu == DocumentStatu.Collected || 
                                     y.PaymentType == PaymentType.Pos && 
                                     y.DocumentStatu == DocumentStatu.InPortfolio)
                    .Sum(y => y.Price);
                    x.Receivable = x.ReceiptDetails.Where(
                                y => y.DocumentStatu == DocumentStatu.Paid)
                    .Sum(y => y.Price);
                });
            //
            return new PagedResultDto<ListBankAccountDto>(totalCount, mappedDto);
        }

        public virtual async Task<SelectBankAccountDto> UpdateAsync(Guid id, UpdateBankAccountDto input)
        {
            var entity = await _bankAccountRepository.GetAsync(id, x => x.Id == id);
            await _bankAccountManager.CheckUpdateAsync(id, input.Code, entity, input.BankDepartmentId, input.SpecialCodeOneId, input.SpecialCodeTwoId);
            //
            var mappedEntity = ObjectMapper.Map(input, entity);
            //
            await _bankAccountRepository.UpdateAsync(mappedEntity);
            //
            return ObjectMapper.Map<BankAccount, SelectBankAccountDto>(mappedEntity);
        }
    }
}
