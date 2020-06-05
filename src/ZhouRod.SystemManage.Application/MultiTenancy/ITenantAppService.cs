using Abp.Application.Services;
using ZhouRod.SystemManage.MultiTenancy.Dto;

namespace ZhouRod.SystemManage.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

