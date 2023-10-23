using LogisticsDataCore.DTOs;
using LogisticsDataCore.Models;

namespace LogisticsDataCore.IValidators
{
    public interface IUserModelFieldsValidator
    {
        public bool IsValidEmail(string email);

        public bool IsValidAge(int age);

        public bool IsValidUsername(string username);

        public bool IsValidPhone(string phone);

        public bool IsValidPassword(string password);

        public RegisterErrorsModel ValidateUserFields(UserRequestDTO userRequestDTO, out int StatusCode);

    }
}
