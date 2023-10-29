using LogisticsDataCore.Constants;
using LogisticsDataCore.DTOs;
using LogisticsDataCore.Interfaces.IValidators;
using LogisticsDataCore.Models;

namespace LogisticsEntity.ModelsFieldsValidator
{
    public class StoreCreationValidator : IStoreCreationValidator
    {

        public MessagesModel ValidateStore(StoreRequestDTO storeDto, Store store, List<Governorate> Govs, out int StatusCode)
        {
            MessagesModel errorsModel = new MessagesModel();

            if (store is not null)
            {
                errorsModel.Message = StoreErrors.StoreExistsError;
                StatusCode = 400;
                return errorsModel;
            }
            else if (!IsGovernorateIDExists(Govs, storeDto.StoreGovernorateName))
            {
                errorsModel.Message = StoreErrors.InvalidStoreGovID;
                StatusCode = 400;
                return errorsModel;
            }else if (storeDto.StoreName is null)
            {
                errorsModel.Message = StoreErrors.StoreNameCantBeEmpty;
                StatusCode = 400;
                return errorsModel;
            }
            else
            {
                StatusCode = 200;
                return errorsModel;
            }
        }

        private bool IsGovernorateIDExists(List<Governorate> govs, string govName)
        {
            foreach (Governorate g in govs)
            {
                if (g.GovernorateName == govName)
                    return true;
            }

            return false;
        }

    }
}
