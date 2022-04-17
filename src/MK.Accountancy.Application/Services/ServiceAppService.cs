using MK.Accountancy.CommonDtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Services
{
    public class ServiceAppService : AccountancyAppService, IServiceAppService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceAppService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public Task<SelectServiceDto> CreateAsync(CreateServiceDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SelectServiceDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCodeAsync(CodeParameterDto input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<ListServiceDto>> GetListAsync(ServiceListParameterDto input)
        {
            throw new NotImplementedException();
        }

        public Task<SelectServiceDto> UpdateAsync(Guid id, UpdateServiceDto input)
        {
            throw new NotImplementedException();
        }
    }
}
