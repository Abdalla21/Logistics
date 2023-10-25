using LogisticsDataCore.Constants;
using LogisticsDataCore.DTOs;
using LogisticsDataCore.Interfaces.IValidators;
using LogisticsDataCore.Models;
using LogisticsProject;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LogisticsEntity.ModelsFieldsValidator
{
    public class UserModelFieldsValidator : IUserModelFieldsValidator
    {
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public bool IsValidAge(int age)
        {
            if (age <= AuthConstants.MinAge || age >= AuthConstants.MaxAge)
                return false;
            else
                return true;
        }

        public bool IsValidUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;
            else
                return true;
        }

        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;
            else if (password.Length < AuthConstants.MinPasswordLength)
                return false;
            else
                return true;
        }

        public bool IsValidPhone(string phone)
        {

            if (phone != null) 
                return Regex.IsMatch(phone, RegexConstants.PhoneRegex);
            else 
                return false;
        }


        public ErrorsModel ValidateUserFields(UserRequestDTO userRequestDTO, out int StatusCode)
        {

            ErrorsModel registerErrorsModel = new ErrorsModel();

            if (!IsValidEmail(userRequestDTO.Email))
            {
                registerErrorsModel.ErrorMessage = RegisterErrorMessagesConstants.EmailNotValid;
                StatusCode = AuthConstants.EmailNotValidStatusCode;
                return registerErrorsModel;
            }
            else if (!IsValidAge(userRequestDTO.Age))
            {
                registerErrorsModel.ErrorMessage = RegisterErrorMessagesConstants.AgeNotValid;
                StatusCode = AuthConstants.AgeNotValidStatusCode;
                return registerErrorsModel;
            }
            else if (!IsValidUsername(userRequestDTO.UserName))
            {
                registerErrorsModel.ErrorMessage = RegisterErrorMessagesConstants.UsernameNotValid;
                StatusCode = AuthConstants.UsernameNotValidStatusCode;
                return registerErrorsModel;
            }
            else if (!IsValidPhone(userRequestDTO.Phone))
            {
                registerErrorsModel.ErrorMessage = RegisterErrorMessagesConstants.PhoneNotValid;
                StatusCode = AuthConstants.PhoneNotValidStatusCode;
                return registerErrorsModel;
            }
            else if (!IsValidPassword(userRequestDTO.Password))
            {
                registerErrorsModel.ErrorMessage = RegisterErrorMessagesConstants.PasswordNotValid;
                StatusCode = AuthConstants.PasswordNotValidStatusCode;
                return registerErrorsModel;
            }
            else
            {
                StatusCode = 200;
                return registerErrorsModel;
            }
        }

    }
}
