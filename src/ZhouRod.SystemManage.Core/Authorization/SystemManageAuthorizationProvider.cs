using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ZhouRod.SystemManage.Authorization
{
    public class SystemManageAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            context.CreatePermission(PermissionNames.Pages_SMusers, L("SMUsers"));
            context.CreatePermission(PermissionNames.Pages_TMTasks, L("TMTasks"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SystemManageConsts.LocalizationSourceName);
        }
    }
}
