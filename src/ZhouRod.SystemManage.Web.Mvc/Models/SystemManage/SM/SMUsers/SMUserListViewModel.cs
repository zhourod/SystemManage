﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZhouRod.SystemManage.SystemManageApp.SM.Dto;

namespace ZhouRod.SystemManage.Web.Models.SystemManage.SM.SMUsers
{
    public class SMUserListViewModel
    {
        public IReadOnlyList<SMUserDto> SMUsers { get; set; }
    }
}
