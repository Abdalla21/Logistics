using LogisticsDataCore.Tables;
using Microsoft.EntityFrameworkCore;

namespace LogisticsEntity.DBTableSeed
{
    public class DBRoleSeed(ModelBuilder modelBuilder)
    {
        public void SeedRoles()
        {
            modelBuilder.Entity<Role>().HasData(
                   new Role() { RoleName = "Admin", RoleDescription = "Has All The privileges for the current tenant.", RoleID = 1 },
                   new Role() { RoleName = "Branch Manager", RoleDescription = "Has All The privileges for the current Branch.", RoleID = 2 },
                   new Role() { RoleName = "Logistic", RoleDescription = "Can see the materials which is lacking in the branches.", RoleID = 3 }

            );
        }
    }
}
