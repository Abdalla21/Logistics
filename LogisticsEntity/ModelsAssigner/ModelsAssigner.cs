﻿using LogisticsDataCore.Constants;
using LogisticsDataCore.Models;
using LogisticsProject;

namespace LogisticsEntity.ModelsAssigner
{
    public class ModelsAssigner
    {

        public JWTTokenModel AssignTokenModel(string token)
        {

            JWTTokenModel tokenModel = new JWTTokenModel();

            tokenModel.Token = token;
            tokenModel.ExpireDate = DateTime.Now.AddHours(AuthConstants.JWTTokenExpireDateByHours).ToString(GlobalConstants.DateTimeFormat);
            tokenModel.TokenType = AuthConstants.TokenType;

            return tokenModel;
        }

        public MessagesModel AssignErrorMessage(string Msg)
        {
            MessagesModel registerErrorsModel = new MessagesModel();

            registerErrorsModel.Message = Msg;

            return registerErrorsModel;
        }

    }
}
