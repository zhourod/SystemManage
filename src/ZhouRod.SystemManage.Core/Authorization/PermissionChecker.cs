using Abp.Authorization;
using ZhouRod.SystemManage.Authorization.Roles;
using ZhouRod.SystemManage.Authorization.Users;

namespace ZhouRod.SystemManage.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
