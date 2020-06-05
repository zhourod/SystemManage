using Abp.Application.Services.Dto;

namespace ZhouRod.SystemManage.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

