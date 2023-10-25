using LogisticsDataCore.DTOs;
using LogisticsDataCore.Models;

namespace LogisticsDataCore.Interfaces.IValidators
{
    public interface IStoreCreationValidator
    {
        ErrorsModel ValidateStore(StoreRequestDTO storeDto, Store store, List<Governorate> Govs, out int StatusCode);

    }
}
