using Microsoft.Extensions.Localization;
using MK.Accountancy.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MK.Accountancy.Blazor;

[Dependency(ReplaceServices = true)]
public class AccountancyBrandingProvider : DefaultBrandingProvider
{
    private readonly IStringLocalizer<AccountancyResource> _localizer;

    public AccountancyBrandingProvider(IStringLocalizer<AccountancyResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => $"MK {_localizer["Pre-Accounting"]}";
}
