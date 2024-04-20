using LogisticsDataCore.DTOs.UserDTOs;
using LogisticsDataCore.Models;

namespace LogisticsDataCore.Interfaces.IValidators
{
    public interface IUserModelFieldsValidator
    {
        public bool IsValidEmail(string email);

        public bool IsValidAge(int age);

        public bool IsValidUsername(string username);

        public bool IsValidPhone(string phone);

        public bool IsValidPassword(string password);

        public MessagesModel ValidateUserFields(UserRequestDTO userRequestDTO, out int StatusCode);

    }
}
