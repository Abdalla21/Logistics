using LogisticsDataCore.Constants;
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

        public RegisterErrorsModel AssignErrorMessage(string Msg)
        {
            RegisterErrorsModel registerErrorsModel = new RegisterErrorsModel();

            registerErrorsModel.ErrorMessage = Msg;

            return registerErrorsModel;
        }

    }
}
