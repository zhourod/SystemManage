using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ZhouRod.SystemManage.Controllers
{
    public abstract class SystemManageControllerBase: AbpController
    {
        protected SystemManageControllerBase()
        {
            LocalizationSourceName = SystemManageConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
