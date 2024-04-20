using LogisticsDataCore.Tables;
using LogisticsEntity.DBTableSeed;
using Microsoft.EntityFrameworkCore;

namespace LogisticsEntity.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasOne<Governorate>()
                .WithMany()
                .HasForeignKey(store => store.StoreGovernorateID);

            new DBRoleSeed(modelBuilder).SeedRoles();
            new DBGovernoratesSeed(modelBuilder).SeedGovernorates();
            new DBUserSeed(modelBuilder).SeedUser();
        }


        public DbSet<User> users { get; set; }

        public DbSet<Governorate> Governorates { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}
