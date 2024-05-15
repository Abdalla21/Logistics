using LogisticsDataCore.DTOs;

namespace LogisticsDataCore.Constants.ControllersConstants
{
    public class AuthConstants
    {
        public readonly static int JWTTokenExpireDateByHours = 1;

        public readonly static string TokenType = "Bearer";

        public readonly static int MinAge = 15;

        public readonly static int MaxAge = 70;

        public readonly static int MinPasswordLength = 8;

        public readonly static int EmailNotValidStatusCode = 471;

        public readonly static int AgeNotValidStatusCode = 472;

        public readonly static int UsernameNotValidStatusCode = 473;

        public readonly static int PhoneNotValidStatusCode = 474;

        public readonly static int PasswordNotValidStatusCode = 475;

        public readonly static int UserExistsStatusCode = 476;

        public readonly static int EmailExistsStatusCode = 477;

        public readonly static string SuccessfullVerification = "Your Email Has Been Verified.";

        public static string GetSuccessfullRegistrationMsg(string Username)
        {
            return $"User {Username} Registered Successfully. A Verification Code Has Been Sent To Your Email.";
        }



    }
}
