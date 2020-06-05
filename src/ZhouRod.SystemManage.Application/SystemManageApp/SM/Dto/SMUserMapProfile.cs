using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZhouRod.SystemManage.SystemManage.SM;

namespace ZhouRod.SystemManage.SystemManageApp.SM.Dto
{
    public class SMUserMapProfile: Profile
    {
        public SMUserMapProfile()
        {
            CreateMap<SMUser, SMUserDto>();
            CreateMap<SMUserDto, SMUser>();
            CreateMap<SMUserDto, SMUser>()
                .ForMember(x => x.CreationTime, opt => opt.Ignore());
        }
    }
}
