using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ZhouRod.SystemManage.Authorization.Roles;
using ZhouRod.SystemManage.Authorization.Users;
using ZhouRod.SystemManage.MultiTenancy;
using ZhouRod.SystemManage.SystemManage.SM;
using ZhouRod.SystemManage.SystemManage.TM;

namespace ZhouRod.SystemManage.EntityFrameworkCore
{
    public class SystemManageDbContext : AbpZeroDbContext<Tenant, Role, User, SystemManageDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public SystemManageDbContext(DbContextOptions<SystemManageDbContext> options)
            : base(options)
        {
        }

        public DbSet<SMUser> SMUser { get; set; }

        public DbSet<TMPerson> TMPerson { get; set; }

        public DbSet<TMTask> TMTask { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
