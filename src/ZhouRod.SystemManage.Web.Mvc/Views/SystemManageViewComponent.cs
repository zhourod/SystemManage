using Abp.AspNetCore.Mvc.ViewComponents;

namespace ZhouRod.SystemManage.Web.Views
{
    public abstract class SystemManageViewComponent : AbpViewComponent
    {
        protected SystemManageViewComponent()
        {
            LocalizationSourceName = SystemManageConsts.LocalizationSourceName;
        }
    }
}
