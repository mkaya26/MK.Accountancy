using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MK.Accountancy.Blazor;

[Dependency(ReplaceServices = true)]
public class AccountancyBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Accountancy";
}
