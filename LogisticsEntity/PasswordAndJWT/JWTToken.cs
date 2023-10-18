using LogisticsDataCore.IPasswordAndJWT;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LogisticsDataCore.DTOs;
using System.IdentityModel.Tokens.Jwt;
using LogisticsProject;

namespace LogisticsEntity.PasswordAndJWT
{
    public class JWTToken : IJWTToken
    {

        public string GetJWTToken(UserResponseDTO userDTO, string PrivateKey)
        {
            List<Claim> claimsList = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userDTO.UserName),
                new Claim(ClaimTypes.Role, userDTO.Role)
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
