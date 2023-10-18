using LogisticsDataCore.DTOs;
using LogisticsDataCore.DTOsConverter;
using LogisticsDataCore.IPasswordHash;
using LogisticsDataCore.Models;
using LogisticsEntity.ModelsAssigner;
using LogisticsEntity.PasswordAndJWT;
using LogisticsEntity.PasswordHash;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LogisticsProject.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IConfiguration Configuration) : ControllerBase
    {

        [HttpPost("register")]
        public ActionResult<User> Register(UserRequestDTO userRequestDTO)
        {
            DTOsConverter dTOsConverter = new DTOsConverter();

            return Ok(dTOsConverter.ConvertUserRequestDTOToUser(userRequestDTO));
        }


        [HttpGet("Roles")]
        public ActionResult<List<string>> GetRoles()
        {
            return Ok(AuthConstants.Roles);
        }


        [HttpPost()]
        public ActionResult<JWTTokenModel> Login(UserResponseDTO user)
        {
            PasswordHash _PasswordHash = new PasswordHash();
            bool isVerified = _PasswordHash.VerifyPassword(user.Password, user.Hash, user.Salt);

            if (isVerified)
            {
                JWTToken tokenClass = new JWTToken();
                ModelsAssigner modelsAssigner = new ModelsAssigner();

                string privateKey = Configuration.GetSection("JWT:Key").Value!;

                string token = tokenClass.GetJWTToken(user, privateKey);

                return Ok(modelsAssigner.AssignTokenModel(token));
            }
            else
                return BadRequest();
        }

    }
}
