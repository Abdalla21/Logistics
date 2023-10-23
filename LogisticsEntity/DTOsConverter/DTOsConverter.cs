using LogisticsDataCore.Constants;
using LogisticsDataCore.DTOs;
using LogisticsDataCore.Models;
using LogisticsEntity.PasswordHash;

namespace LogisticsDataCore.DTOsConverter
{
    public class DTOsConverter
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
                CreatedDateTime = DateTime.Now.ToString(GlobalConstants.DateTimeFormat)
            };

            return user;
        }

    }
}
