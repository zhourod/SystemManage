using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ZhouRod.SystemManage.EntityFrameworkCore;
using ZhouRod.SystemManage.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ZhouRod.SystemManage.Web.Tests
{
    [DependsOn(
        typeof(SystemManageWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SystemManageWebTestModule : AbpModule
    {
        public SystemManageWebTestModule(SystemManageEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SystemManageWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SystemManageWebMvcModule).Assembly);
        }
    }
}