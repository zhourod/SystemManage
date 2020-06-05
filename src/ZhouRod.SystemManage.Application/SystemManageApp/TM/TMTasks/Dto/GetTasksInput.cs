using System;
using System.Collections.Generic;
using System.Text;
using ZhouRod.SystemManage.SystemManage.TM;

namespace ZhouRod.SystemManage.SystemManageApp.TM.TMTasks.Dto
{
    public class GetTasksInput
    {
        public TaskState? State { get; set; }

        public int? AssignedPersonId { get; set; }
    }
}
