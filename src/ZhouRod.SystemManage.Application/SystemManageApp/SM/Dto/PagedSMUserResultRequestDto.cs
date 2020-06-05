using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhouRod.SystemManage.SystemManageApp.SM.Dto
{
    public class PagedSMUserResultRequestDto: PagedResultRequestDto
    {
        public string Keyword { get; set; }

        public bool? IsActive { get; set; }
    }
}
