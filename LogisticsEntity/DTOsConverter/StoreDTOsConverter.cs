using LogisticsDataCore.DTOs;
using LogisticsDataCore.Models;

namespace LogisticsDataCore.DTOsConverter
{
    public static class StoreDTOsConverter
    {
        public static Store ConvertStoreRequestDTOToStore(this StoreRequestDTO dto, int GovID, int UserID)
        {

            Store store = new Store
            {
                StoreName = dto.StoreName,
                StoreCityLocation = dto.StoreCityLocation,
                StoreDescription = dto.StoreDescription,
                StoreGovernorateID = GovID,
                StoreManagerID = UserID,
            };

            return store;
        }

        public static StoreRequestDTO ConvertStoreToStoreDto(this Store store, string username, string govName)
        {

            StoreRequestDTO storeDto = new StoreRequestDTO
            (
                store.StoreID,
                store.StoreName,
                store.StoreCityLocation,
                store.StoreDescription,
                govName,
                username
            );

            return storeDto;

        }


    }
}
