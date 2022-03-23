using MK.Accountancy.Localization;
using Volo.Abp.AspNetCore.Components;

namespace MK.Accountancy.Blazor;

public abstract class AccountancyComponentBase : AbpComponentBase
{
    protected AccountancyComponentBase()
    {
        LocalizationResource = typeof(AccountancyResource);
    }
}
