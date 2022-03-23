using MK.Accountancy.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MK.Accountancy.Permissions;

public class AccountancyPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AccountancyPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AccountancyPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AccountancyResource>(name);
    }
}
