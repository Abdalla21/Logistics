using System;
namespace LogisticsDataCore.IPasswordHash
{
    public interface IPasswordHash
    {
        public string HashPassword(string password);

        public bool VerifyPassword(string password, string passwordHash);
    }
}
