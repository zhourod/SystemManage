using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZhouRod.SystemManage.SystemManage.SM
{
    public class SMUser: FullAuditedEntity<int>, IPassivable
    {
        public const int MaxUserAccountLength = 50;
        public const int MaxEmailLength = 50;

        [Required]
        [StringLength(MaxUserAccountLength)]
        public string UserAccount { get; set; }

        [Required]
        [StringLength(MaxEmailLength)]
        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
