using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZhouRod.SystemManage.SystemManageApp.TM.TMTasks.Dto
{
   public class TMTaskDto: EntityDto<int>
    {
        //[Required]
        public int? AssignedPersonId { get; set; }

        public string AssignedPersonName { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        [Required]
        public byte State { get; set; }
    }
}
