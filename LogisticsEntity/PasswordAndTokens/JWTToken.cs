using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using LogisticsProject;
using LogisticsDataCore.Models;
using LogisticsDataCore.Interfaces.IPasswordAndJWT;

namespace LogisticsEntity.PasswordAndTokens
{
    public class JWTToken : IJWTToken
    {

        public string GetJWTToken(User user, string PrivateKey)
        {
            List<Claim> claimsList = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role!)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PrivateKey));

            SigningCredentials encodingAlgo = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claimsList,
                expires: DateTime.Now.AddHours(AuthConstants.JWTTokenExpireDateByHours),
                signingCredentials: encodingAlgo
                );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

    }
}
