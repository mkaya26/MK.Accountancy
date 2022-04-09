using MK.Accountancy.Abstract;
using MK.Accountancy.CommonDtos;

namespace MK.Accountancy.Services
{
    public interface IServiceAppService : ICrudAppService<SelectServiceDto, ListServiceDto, ServiceListParameterDto, CreateServiceDto, UpdateServiceDto, CodeParameterDto>
    {
    }
}
