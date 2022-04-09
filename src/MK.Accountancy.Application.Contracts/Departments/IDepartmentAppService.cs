using MK.Accountancy.Abstract;
using MK.Accountancy.CommonDtos;

namespace MK.Accountancy.Departments
{
    public interface IDepartmentAppService : ICrudAppService<SelectDepartmentDto, ListDepartmentDto, DepartmentListParameterDto, CreateDepartmentDto, UpdateDepartmentDto, CodeParameterDto>
    {
    }
}
