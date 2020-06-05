using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ZhouRod.SystemManage.SystemManage.SM;

namespace ZhouRod.SystemManage.SystemManageApp.SM.Dto
{
    public class SMUserDto: FullAuditedEntityDto<int>
    {
        [Required]
        [StringLength(SMUser.MaxUserAccountLength)]
        public string UserAccount { get; set; }

        [Required]
        [StringLength(SMUser.MaxEmailLength)]
        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
