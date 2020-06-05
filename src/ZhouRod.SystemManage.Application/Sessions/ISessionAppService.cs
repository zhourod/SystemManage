using System.Threading.Tasks;
using Abp.Application.Services;
using ZhouRod.SystemManage.Sessions.Dto;

namespace ZhouRod.SystemManage.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
