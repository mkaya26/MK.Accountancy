using Volo.Abp.Settings;

namespace MK.Accountancy.Settings;

public class AccountancySettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AccountancySettings.MySetting1));
    }
}
