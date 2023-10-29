using LogisticsDataCore.Constants;
using LogisticsDataCore.DTOs;
using LogisticsDataCore.DTOsConverter;
using LogisticsDataCore.Interfaces.IRepositories;
using LogisticsDataCore.Interfaces.IUnitOfWork;
using LogisticsDataCore.Models;
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
    public class AuthController(IConfiguration Configuration, IUnitOfWork unitOfWork) : ControllerBase
    {

        [HttpPost()]
        public ActionResult Register(UserRequestDTO userRequestDTO)
        {
            DTOsConverter dTOsConverter = new DTOsConverter();
            UserModelFieldsValidator userModelFieldsValidator = new UserModelFieldsValidator();
            ModelsAssigner modelsAssigner = new ModelsAssigner();
            SuccessModel successModel = new SuccessModel();

            User userByEmail = unitOfWork.Users.Get(user => user.Email == userRequestDTO.Email);

            int statusCode = 0;

            if (userByEmail != null)
                return StatusCode(AuthConstants.EmailExistsStatusCode, modelsAssigner.AssignErrorMessage(RegisterErrorMessagesConstants.EmailAlreadyExists));

            User userByUserName = unitOfWork.Users.Get(user => user.UserName == userRequestDTO.UserName);

            if (userByUserName != null)
                return StatusCode(AuthConstants.UserExistsStatusCode, modelsAssigner.AssignErrorMessage(RegisterErrorMessagesConstants.UserNameAlreadyExists));


            ErrorsModel registerErrorsModel = userModelFieldsValidator.ValidateUserFields(userRequestDTO, out statusCode);

            if (statusCode == 200)
            {
                User user = dTOsConverter.ConvertUserRequestDTOToUser(userRequestDTO);
                unitOfWork.Users.Save(user);
                unitOfWork.Complete();
                successModel.SuccessMsg = AuthConstants.GetSuccessfullRegistrationMsg(userRequestDTO.UserName);
                return Ok(successModel);
            }
            else
            {
                return StatusCode(statusCode, registerErrorsModel);
            }

        }


        [HttpPost()]
        public ActionResult<JWTTokenModel> Login(UserResponseDTO user)
        {
            User userSelected = unitOfWork.Users.Get(u => u.Email == user.Email);

            if (userSelected is null)
                return Unauthorized();

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
