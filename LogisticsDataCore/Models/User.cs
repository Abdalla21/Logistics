using System.ComponentModel.DataAnnotations;

namespace LogisticsDataCore.Models
{
    public class User
    {
        public int UserID { get; set; }

        public required string UserName { get; set; }

        public required byte[] PasswordHash { get; set; }

        public required byte[] PasswordSalt { get; set; }

        public required int Age { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public required string Role { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }
}
