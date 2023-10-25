using LogisticsDataCore.DTOs;
using LogisticsDataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsDataCore.Interfaces.IPasswordAndJWT
{
    public interface IJWTToken
    {
        public string GetJWTToken(User user, string PrivateKey);
    }
}
