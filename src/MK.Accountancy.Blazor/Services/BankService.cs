using MK.Accountancy.BankAccounts;
using MK.Accountancy.Banks;
using MK.Accountancy.Blazor.Services.Base;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class BankService : BaseService<BankListDto,SelectBankDto>,IScopedDependency
    {
        public override void SelectEntity(IEntityDto targetEntity)
        {
            if(targetEntity is SelectBankAccountDto bankAccountDto)
            {
                bankAccountDto.BankId = SelectedItem.Id;
                bankAccountDto.BankName = SelectedItem.Name;
            }
        }
    }
}
