using LogisticsDataCore.Constants;
using LogisticsDataCore.DTOs;
using LogisticsDataCore.DTOsConverter;
using LogisticsDataCore.Models;
using LogisticsDataCore.Repositories;
using LogisticsEntity.ModelsAssigner;
using LogisticsEntity.ModelsFieldsValidator;
using LogisticsEntity.PasswordAndJWT;
using LogisticsEntity.PasswordHash;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace LogisticsProject.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IConfiguration Configuration, IGenericRepository<User> repository) : ControllerBase
    {

        [HttpPost("register")]
        public ActionResult<User> Register(UserRequestDTO userRequestDTO)
        {
            DTOsConverter dTOsConverter = new DTOsConverter();
            UserModelFieldsValidator userModelFieldsValidator = new UserModelFieldsValidator();

            int statusCode = 0;

            RegisterErrorsModel registerErrorsModel = userModelFieldsValidator.ValidateUserFields(userRequestDTO, out statusCode);

            if (statusCode == 200)
            {
                User user = dTOsConverter.ConvertUserRequestDTOToUser(userRequestDTO);
                repository.SaveUser(user);

                return Ok();
            }
            else
            {
                return StatusCode(statusCode, registerErrorsModel);
            }

        }


        [HttpGet("Roles"), Authorize(Roles = "Admin")]
        public ActionResult<List<string>> GetRoles()
        {
            return Ok(UsersRolesConstants.Roles);
        }


        [HttpPost()]
        public ActionResult<JWTTokenModel> Login(UserResponseDTO user)
        {
            User userSelected = repository.GetUser(u => u.Email == user.Email);

            if (userSelected is null)
                return BadRequest();

            PasswordHash PasswordHash = new PasswordHash();
            bool isVerified = PasswordHash.VerifyPassword(user.Password, userSelected.PasswordHash);

            if (isVerified)
            {
                JWTToken tokenClass = new JWTToken();
                ModelsAssigner modelsAssigner = new ModelsAssigner();

                string privateKey = Configuration.GetSection("JWT:Key").Value!;

                string token = tokenClass.GetJWTToken(userSelected, privateKey);

                return Ok(modelsAssigner.AssignTokenModel(token));
            }
            else
                return Unauthorized();
        }

    }
}
