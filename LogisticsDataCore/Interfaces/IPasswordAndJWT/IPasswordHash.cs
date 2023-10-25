using System;

namespace LogisticsDataCore.Interfaces.IPasswordAndJWT
{
    public interface IPasswordHash
    {
        public string HashPassword(string password);

        public bool VerifyPassword(string password, string passwordHash);
    }
}
