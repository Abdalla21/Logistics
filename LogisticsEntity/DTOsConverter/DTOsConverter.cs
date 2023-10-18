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

            passwordHashClass.HashPassword(dto.Password, out byte[] passwordSalt, out byte[] passwordHash);

            User user = new User
            {
                UserName = dto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Age = dto.Age,
                Email = dto.Email,
                Phone = dto.Phone,
                Role = dto.Role,
                CreatedDateTime = DateTime.Now
            };

            return user;
        }



    }
}
