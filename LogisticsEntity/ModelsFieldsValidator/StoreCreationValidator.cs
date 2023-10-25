﻿using LogisticsDataCore.Constants;
using LogisticsDataCore.DTOs;
using LogisticsDataCore.Interfaces.IValidators;
using LogisticsDataCore.Models;

namespace LogisticsEntity.ModelsFieldsValidator
{
    public class StoreCreationValidator : IStoreCreationValidator
    {

        public ErrorsModel ValidateStore(StoreRequestDTO storeDto, Store store, List<Governorate> Govs, out int StatusCode)
        {
            ErrorsModel errorsModel = new ErrorsModel();

            if (store is not null)
            {
                errorsModel.ErrorMessage = StoreErrors.StoreExistsError;
                StatusCode = 400;
                return errorsModel;
            }
            else if (!IsGovernorateIDExists(Govs, storeDto.StoreGovernorateID))
            {
                errorsModel.ErrorMessage = StoreErrors.InvalidStoreGovID;
                StatusCode = 400;
                return errorsModel;
            }else if (storeDto.StoreName is null)
            {
                errorsModel.ErrorMessage = StoreErrors.StoreNameCantBeEmpty;
                StatusCode = 400;
                return errorsModel;
            }
            else
            {
                StatusCode = 200;
                return errorsModel;
            }
        }

        private bool IsGovernorateIDExists(List<Governorate> govs, int govID)
        {
            foreach (Governorate g in govs)
            {
                if (g.GovernorateID == govID)
                    return true;
            }

            return false;
        }

    }
}