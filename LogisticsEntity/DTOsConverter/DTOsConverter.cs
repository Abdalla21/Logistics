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

        public Store ConvertStoreRequestDTOToStore(StoreRequestDTO dto, int GovID, int UserID)
        {

            Store store = new Store
            {
                StoreName = dto.StoreName,
                StoreCityLocation = dto.StoreCityLocation,
                StoreDescription = dto.StoreDescription,
                StoreGovernorateID = GovID,
                StoreManagerID = UserID,
                CreatedDateTime = DateTime.Now.ToString(GlobalConstants.DateTimeFormat)
            };

            return store;
        }

    }
}
