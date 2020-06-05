using System.Threading.Tasks;
using Abp.Application.Services;
using ZhouRod.SystemManage.Authorization.Accounts.Dto;

namespace ZhouRod.SystemManage.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
