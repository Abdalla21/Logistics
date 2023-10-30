using LogisticsDataCore.DTOs;
using LogisticsDataCore.Models;

namespace LogisticsDataCore.DTOsConverter
{
    public class StoreDTOsConverter
    {
        public Store ConvertStoreRequestDTOToStore(StoreRequestDTO dto, int GovID, int UserID)
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

        public StoreRequestDTO ConvertStoreToStoreDto(Store store, string username, string govName)
        {

            StoreRequestDTO storeDto = new StoreRequestDTO
            {
                StoreID = store.StoreID,
                StoreName = store.StoreName,
                StoreCityLocation = store.StoreCityLocation,
                StoreDescription = store.StoreDescription,
                StoreGovernorateName = govName,
                StoreManagerName = username,
            };

            return storeDto;

        }


    }
}
