using Abp.AutoMapper;
using ZhouRod.SystemManage.Sessions.Dto;

namespace ZhouRod.SystemManage.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
