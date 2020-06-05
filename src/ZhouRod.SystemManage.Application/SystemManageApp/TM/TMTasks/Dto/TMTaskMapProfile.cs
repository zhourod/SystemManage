using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZhouRod.SystemManage.SystemManage.TM;

namespace ZhouRod.SystemManage.SystemManageApp.TM.TMTasks.Dto
{
    public class TMTaskMapProfile:Profile
    {
        public TMTaskMapProfile()
        {
            CreateMap<TMTask, TMTaskDto>();
            CreateMap<TMTaskDto, TMTask>();
            CreateMap<TMTaskDto, TMTask>()
                .ForMember(x => x.CreationTime, opt => opt.Ignore());
        }
    }
}
