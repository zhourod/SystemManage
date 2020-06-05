using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ZhouRod.SystemManage.EntityFrameworkCore
{
    public static class SystemManageDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SystemManageDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SystemManageDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
