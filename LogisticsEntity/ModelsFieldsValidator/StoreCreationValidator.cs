using LogisticsDataCore.Constants;
using LogisticsDataCore.DTOs;
using LogisticsDataCore.Interfaces.IValidators;
using LogisticsDataCore.Models;
using LogisticsDataCore.Tables;

namespace LogisticsEntity.ModelsFieldsValidator
{
    public class StoreCreationValidator : IStoreCreationValidator
    {

        public MessagesModel ValidateStore(StoreRequestDTO storeDto, Store store, List<Governorate> Govs, out int StatusCode)
        {
            MessagesModel errorsModel = new MessagesModel();

            if (store is not null)
            {
                errorsModel.Message = StoreMessages.StoreExistsError;
                StatusCode = 400;
                return errorsModel;
            }
            else if (!IsGovernorateIDExists(Govs, storeDto.StoreGovernorateName))
            {
                errorsModel.Message = StoreMessages.InvalidStoreGovID;
                StatusCode = 400;
                return errorsModel;
            }else if (storeDto.StoreName is null)
            {
                errorsModel.Message = StoreMessages.StoreNameCantBeEmpty;
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
