using MK.Accountancy.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MK.Accountancy.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AccountancyController : AbpControllerBase
{
    protected AccountancyController()
    {
        LocalizationResource = typeof(AccountancyResource);
    }
}
