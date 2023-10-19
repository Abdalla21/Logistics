using LogisticsDataCore.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsEntity.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }

        public DbSet<User> users { get; set; }

    }
}
