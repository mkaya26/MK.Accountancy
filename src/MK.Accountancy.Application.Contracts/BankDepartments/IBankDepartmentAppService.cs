using MK.Accountancy.Abstract;

namespace MK.Accountancy.BankDepartments
{
    public interface IBankDepartmentAppService : ICrudAppService<SelectBankDepartmentDto, ListBankDepartmentDto, BankDepartmentListParameterDto, CreateBankDepartmentDto, UpdateBankDepartmentDto, BankDepartmentCodeParameterDto>
    {
    }
}
