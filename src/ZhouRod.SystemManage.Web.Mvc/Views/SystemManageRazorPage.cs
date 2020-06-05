using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace ZhouRod.SystemManage.Web.Views
{
    public abstract class SystemManageRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected SystemManageRazorPage()
        {
            LocalizationSourceName = SystemManageConsts.LocalizationSourceName;
        }
    }
}
