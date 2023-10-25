using System.ComponentModel.DataAnnotations;

namespace LogisticsDataCore.Models
{
    public class User
    {
        public int UserID { get; set; }

        public required string UserName { get; set; }

        public required string PasswordHash { get; set; }

        public required int Age { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public string? Role { get; set; }

        public required string CreatedDateTime { get; set; }

    }
}
