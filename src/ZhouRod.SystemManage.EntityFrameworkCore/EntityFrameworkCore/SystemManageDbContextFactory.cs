using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ZhouRod.SystemManage.Configuration;
using ZhouRod.SystemManage.Web;

namespace ZhouRod.SystemManage.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SystemManageDbContextFactory : IDesignTimeDbContextFactory<SystemManageDbContext>
    {
        public SystemManageDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SystemManageDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SystemManageDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SystemManageConsts.ConnectionStringName));

            return new SystemManageDbContext(builder.Options);
        }
    }
}
