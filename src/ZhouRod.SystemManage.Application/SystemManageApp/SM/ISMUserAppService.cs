using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using ZhouRod.SystemManage.SystemManageApp.SM.Dto;

namespace ZhouRod.SystemManage.SystemManageApp.SM
{
    public interface ISMUserAppService : IAsyncCrudAppService<SMUserDto, int, PagedSMUserResultRequestDto, SMUserDto, SMUserDto>
    {
       
    }
}
