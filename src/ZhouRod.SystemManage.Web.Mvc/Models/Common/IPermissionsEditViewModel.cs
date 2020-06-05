using System.Collections.Generic;
using ZhouRod.SystemManage.Roles.Dto;

namespace ZhouRod.SystemManage.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}