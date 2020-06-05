using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZhouRod.SystemManage.SystemManage.TM;

namespace ZhouRod.SystemManage.SystemManageApp.TM.People.Dto
{
    public class TMPersonMapProfile: Profile
    {
        public TMPersonMapProfile()
        {
            CreateMap<TMPerson, TMPersonDto>();
            
        }
    }
}
