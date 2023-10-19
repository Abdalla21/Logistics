﻿using LogisticsDataCore.IPasswordHash;
using System.Security.Cryptography;
using System.Text;

namespace LogisticsEntity.PasswordHash
{
    public class PasswordHash : IPasswordHash
    {

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

    }
}
