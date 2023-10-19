using LogisticsDataCore.Constants;
using LogisticsDataCore.DTOs;
using LogisticsDataCore.IValidators;
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
            if (age <= AuthConstants.MinAge)
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

        public bool IsValidRole(string role)
        {
            if (UsersRolesConstants.Roles.Contains(role))
                return true;
            else
                return false;
        }

        public RegisterErrorsModel ValidateUserFields(UserRequestDTO userRequestDTO, out int StatusCode)
        {

            RegisterErrorsModel registerErrorsModel = new RegisterErrorsModel();

            if (!IsValidEmail(userRequestDTO.Email))
            {
                registerErrorsModel.ErrorMessage = RegisterErrorMessagesConstants.EmailNotValid;
                StatusCode = 471;
                return registerErrorsModel;
            }
            else if (!IsValidAge(userRequestDTO.Age))
            {
                registerErrorsModel.ErrorMessage = RegisterErrorMessagesConstants.AgeNotValid;
                StatusCode = 472;
                return registerErrorsModel;
            }
            else if (!IsValidUsername(userRequestDTO.UserName))
            {
                registerErrorsModel.ErrorMessage = RegisterErrorMessagesConstants.UsernameNotValid;
                StatusCode = 473;
                return registerErrorsModel;
            }
            else if (!IsValidPhone(userRequestDTO.Phone))
            {
                registerErrorsModel.ErrorMessage = RegisterErrorMessagesConstants.PhoneNotValid;
                StatusCode = 474;
                return registerErrorsModel;
            }
            else if (!IsValidPassword(userRequestDTO.Password))
            {
                registerErrorsModel.ErrorMessage = RegisterErrorMessagesConstants.PasswordNotValid;
                StatusCode = 475;
                return registerErrorsModel;
            }
            else if (!IsValidRole(userRequestDTO.Role))
            {
                registerErrorsModel.ErrorMessage = RegisterErrorMessagesConstants.RoleNotValid;
                StatusCode = 476;
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
