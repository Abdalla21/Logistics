using LogisticsDataCore.DTOs;
using LogisticsDataCore.Models;
using LogisticsEntity.Password;

namespace LogisticsEntity.DTOsConverter
{
    public class UserDTOsConverter
    {
        public User ConvertUserRequestDTOToUser(UserRequestDTO dto)
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
