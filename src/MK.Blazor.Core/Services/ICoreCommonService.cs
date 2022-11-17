using Microsoft.AspNetCore.Components;

namespace MK.Blazor.Core.Services
{
    public interface ICoreCommonService
    {
        public Action HasChanged { get; set; }
        public ComponentBase ActiveEditComponent { get; set; }
    }
}
