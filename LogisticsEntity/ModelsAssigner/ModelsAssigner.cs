using LogisticsDataCore.Constants;
using LogisticsDataCore.Constants.ControllersConstants;
using LogisticsDataCore.Models;

namespace LogisticsEntity.ModelsAssigner
{
    public class ModelsAssigner
    {

        public JWTTokenModel AssignTokenModel(string token)
        {
            JWTTokenModel tokenModel = new JWTTokenModel()
            {
                Token = token,
                ExpireDate = DateTime.Now.AddHours(AuthConstants.JWTTokenExpireDateByHours).ToString(GlobalConstants.DateTimeFormat),
                TokenType = AuthConstants.TokenType
            };

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
