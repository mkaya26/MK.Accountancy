using System.Threading.Tasks;
using MK.Accountancy.Localization;
using MK.Accountancy.MultiTenancy;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace MK.Accountancy.Blazor.Menus;

public class AccountancyMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<AccountancyResource>();
        //
        context.Menu.Items.Clear();
        //
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AccountancyMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        return Task.CompletedTask;
    }
}
