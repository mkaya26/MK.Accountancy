using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MK.Accountancy.Abstract
{
    public interface ICodeAppService<in TGetCodeInput> : IApplicationService
    {
        Task<string> GetCodeAsync(TGetCodeInput input);
    }
}
