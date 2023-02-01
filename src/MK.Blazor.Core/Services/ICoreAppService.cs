using Volo.Abp.Application.Dtos;

namespace MK.Blazor.Core.Services
{
    public interface ICoreAppService
    {
        public IEntityDto CompanyParameter { get; set; }
    }
}
