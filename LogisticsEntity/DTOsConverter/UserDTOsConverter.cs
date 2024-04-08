using LogisticsDataCore.DTOs;
using LogisticsDataCore.Models;
using LogisticsEntity.Password;

namespace LogisticsEntity.DTOsConverter
{
    public static class UserDTOsConverter
    {
        public static User ConvertUserRequestDTOToUser(this UserRequestDTO dto)
        {
            PasswordHash passwordHashClass = new PasswordHash();

            string HashedPassword = passwordHashClass.HashPassword(dto.Password);

            User user = new User
            {
                UserName = dto.UserName,
                PasswordHash = HashedPassword,
                Age = dto.Age,
                Email = dto.Email,
                Phone = dto.Phone,
            };

            return user;
        }
    }
}
