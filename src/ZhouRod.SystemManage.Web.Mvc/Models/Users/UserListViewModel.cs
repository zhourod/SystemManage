using System.Collections.Generic;
using ZhouRod.SystemManage.Roles.Dto;

namespace ZhouRod.SystemManage.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
