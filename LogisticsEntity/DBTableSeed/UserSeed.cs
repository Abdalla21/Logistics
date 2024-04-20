using LogisticsDataCore.Constants;
using LogisticsDataCore.Tables;
using LogisticsEntity.Password;
using Microsoft.EntityFrameworkCore;

namespace LogisticsEntity.DBTableSeed
{
    public class DBUserSeed(ModelBuilder modelBuilder)
    {
        public void SeedUser()
        {
            PasswordHash hash = new PasswordHash();

            modelBuilder.Entity<User>().HasData(
                   new User() {
                       UserID = 1,
                       UserName = "Admin",
                       Age = 26,
                       Email = "abdalla.ahly@gmail.com", 
                       Phone = "01096796098", 
                       Role = "Admin", 
                       IsVerified = true, 
                       CreatedDateTime = GlobalConstants.getDateTimeNowFormatted(),
                       PasswordHash = hash.HashPassword("12345678")
                   }
            );
        }
    }
}
