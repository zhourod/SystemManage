using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZhouRod.SystemManage.SystemManageApp.TM.People.Dto;
using ZhouRod.SystemManage.SystemManageApp.TM.TMTasks.Dto;

namespace ZhouRod.SystemManage.Web.Models.SystemManage.TM.TMTasks
{
    public class EditTMTaskModalViewModel
    {
        public TMTaskDto TMTask { get; set; }
        public IReadOnlyList<TMPersonDto> TMPersons { get; set; }
    }
}
