using Abp.AutoMapper;
using ZhouRod.SystemManage.Roles.Dto;
using ZhouRod.SystemManage.Web.Models.Common;

namespace ZhouRod.SystemManage.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
