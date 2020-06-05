using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ZhouRod.SystemManage.Authorization;

namespace ZhouRod.SystemManage
{
    [DependsOn(
        typeof(SystemManageCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SystemManageApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SystemManageAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SystemManageApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
