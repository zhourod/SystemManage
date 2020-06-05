using System.Collections.Generic;
using ZhouRod.SystemManage.Roles.Dto;

namespace ZhouRod.SystemManage.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
