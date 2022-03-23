using System;
using System.Collections.Generic;
using System.Text;
using MK.Accountancy.Localization;
using Volo.Abp.Application.Services;

namespace MK.Accountancy;

/* Inherit your application services from this class.
 */
public abstract class AccountancyAppService : ApplicationService
{
    protected AccountancyAppService()
    {
        LocalizationResource = typeof(AccountancyResource);
    }
}
