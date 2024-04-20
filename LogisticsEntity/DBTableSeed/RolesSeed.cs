using LogisticsDataCore.Constants;
using LogisticsDataCore.Tables;
using Microsoft.EntityFrameworkCore;

namespace LogisticsEntity.DBTableSeed
{
    public class DBRoleSeed(ModelBuilder modelBuilder)
    {
        public void SeedRoles()
        {
            modelBuilder.Entity<Role>().HasData(
                   new Role()
                   {
                       RoleName = RoleConstants.AdminRole,
                       RoleDescription = RoleConstants.AdminRoleDesc,
                       RoleID = 1
                   },
                   new Role()
                   {
                       RoleName = RoleConstants.BranchManagerRole,
                       RoleDescription = RoleConstants.BranchManagerRoleDesc,
                       RoleID = 2
                   },
                   new Role()
                   {
                       RoleName = RoleConstants.LogisticRoleRole,
                       RoleDescription = RoleConstants.LogisticRoleRoleDesc,
                       RoleID = 3
                   }

            );
        }
    }
}
