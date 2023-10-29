using System.Security.Cryptography;

namespace LogisticsEntity.PasswordAndTokens
{
    public class EmailVerification
    {
        public static string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(5));
        }

    }
}
