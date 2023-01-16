using Microsoft.AspNetCore.Components;
using MK.Accountancy.Localization;
using Volo.Abp.AspNetCore.Components;

namespace MK.Accountancy.Blazor.Pages.Base
{
    public abstract class BaseEditPage : AbpComponentBase
    {
        public BaseEditPage()
        {
            LocalizationResource = typeof(AccountancyResource);
        }

        [Parameter] public EventCallback OnSubmit { get; set; }
    }
}
