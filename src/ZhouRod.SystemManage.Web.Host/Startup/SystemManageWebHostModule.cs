using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ZhouRod.SystemManage.Configuration;

namespace ZhouRod.SystemManage.Web.Host.Startup
{
    [DependsOn(
       typeof(SystemManageWebCoreModule))]
    public class SystemManageWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SystemManageWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SystemManageWebHostModule).GetAssembly());
        }
    }
}
