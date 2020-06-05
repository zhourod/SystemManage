using Abp.MultiTenancy;
using ZhouRod.SystemManage.Authorization.Users;

namespace ZhouRod.SystemManage.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
