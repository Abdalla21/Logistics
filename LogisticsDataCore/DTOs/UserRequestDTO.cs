using System.ComponentModel.DataAnnotations;

namespace LogisticsDataCore.DTOs
{
    public class UserRequestDTO
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Role { get; set; }


    }
}
