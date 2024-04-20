using LogisticsDataCore.DTOs;
using LogisticsDataCore.Models;
using LogisticsDataCore.Tables;

namespace LogisticsDataCore.Interfaces.IValidators
{
    public interface IStoreCreationValidator
    {
        MessagesModel ValidateStore(StoreRequestDTO storeDto, Store store, List<Governorate> Govs, out int StatusCode);

    }
}
