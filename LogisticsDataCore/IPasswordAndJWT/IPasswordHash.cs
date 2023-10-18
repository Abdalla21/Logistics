using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsDataCore.IPasswordHash
{
    public interface IPasswordHash
    {
        public void HashPassword(string password, out byte[] passwordSalt, out byte[] passwordHashed);

        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
