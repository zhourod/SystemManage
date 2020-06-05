using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ZhouRod.SystemManage.SystemManage.TM;
using ZhouRod.SystemManage.SystemManageApp.TM.TMTasks.Dto;

namespace ZhouRod.SystemManage.SystemManageApp.TM.TMTasks
{
    public interface ITMTaskAppService: IAsyncCrudAppService<TMTaskDto, int, PagedTMTaskResultRequestDto, TMTaskDto, TMTaskDto>
    {
        //GetTasksOutput GetTasks(GetTasksInput input);

        //List<TMTask> GetAllWithPeople(int? assignedPersonId, TaskState? state);

    }
}
