using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZhouRod.SystemManage.SystemManageApp.TM.People.Dto;

namespace ZhouRod.SystemManage.SystemManageApp.TM.People
{
    public interface IPersonAppService: IApplicationService
    {
        //Task<GetAllPeopleOutput> GetAllPeople();
        Task<List<TMPersonDto>> GetAllPeople();
    }
}
