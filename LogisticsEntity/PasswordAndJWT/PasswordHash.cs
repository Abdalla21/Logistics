using LogisticsDataCore.IPasswordHash;
using System.Security.Cryptography;
using System.Text;

namespace LogisticsEntity.PasswordHash
{
    public class PasswordHash : IPasswordHash
    {

        public void HashPassword(string password, out byte[] passwordSalt, out byte[] passwordHashed)
        {
            using (HMACSHA512 sha = new HMACSHA512())
            {

                passwordSalt = sha.Key;
                passwordHashed = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }

        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {

            using (HMACSHA512 sha = new HMACSHA512(passwordSalt))
            {

                byte[] computedHash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }

        }

    }
}
