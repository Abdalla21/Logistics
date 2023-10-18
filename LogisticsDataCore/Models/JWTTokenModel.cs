using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsDataCore.Models
{
    public class JWTTokenModel
    {
        public string Token { get; set; }
        public string ExpireDate { get; set; }
        public string TokenType { get; set; }
    }
}
