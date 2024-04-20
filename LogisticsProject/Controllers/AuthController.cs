using LogisticsDataCore.Constants;
using LogisticsDataCore.DTOs;
using LogisticsDataCore.Interfaces.IEmailService;
using LogisticsDataCore.Interfaces.IUnitOfWork;
using LogisticsDataCore.Models;
using LogisticsEntity.ModelsAssigner;
using LogisticsEntity.ModelsFieldsValidator;
using LogisticsEntity.PasswordAndTokens;
using LogisticsEntity.Password;
using Microsoft.AspNetCore.Mvc;
using LogisticsEntity.DTOsConverter;
using LogisticsDataCore.Tables;

namespace LogisticsProject.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IConfiguration Configuration, IUnitOfWork unitOfWork, IEmailService emailService) : ControllerBase
    {


        [HttpPost()]
        public async Task<ActionResult> Register(UserRequestDTO userRequestDTO)
        {
            UserModelFieldsValidator userModelFieldsValidator = new UserModelFieldsValidator();
            ModelsAssigner modelsAssigner = new ModelsAssigner();
            MessagesModel msgModel = new MessagesModel();

            User userByEmail = unitOfWork.Users.GetSingle(user => user.Email == userRequestDTO.Email);

            int statusCode = 0;

            if (userByEmail != null)
                return StatusCode(AuthConstants.EmailExistsStatusCode, modelsAssigner.AssignErrorMessage(RegisterErrorMessagesConstants.EmailAlreadyExists));

            User userByUserName = unitOfWork.Users.GetSingle(user => user.UserName == userRequestDTO.UserName);

            if (userByUserName != null)
                return StatusCode(AuthConstants.UserExistsStatusCode, modelsAssigner.AssignErrorMessage(RegisterErrorMessagesConstants.UserNameAlreadyExists));

            msgModel = userModelFieldsValidator.ValidateUserFields(userRequestDTO, out statusCode);

            if (statusCode == 200)
            {
                string EmailVerificationToken = EmailVerification.CreateRandomToken();

                User user = userRequestDTO.ConvertUserRequestDTOToUser();
                user.VerificationCode = EmailVerificationToken;

                string Password = Configuration.GetSection("EmailSender:Password").Value!;
                await emailService.SendEmailAsync(userRequestDTO.Email, EmailConstants.Subject, EmailConstants.GetEmailVerficationMsg(EmailVerificationToken), Password);

                msgModel.Message = AuthConstants.GetSuccessfullRegistrationMsg(userRequestDTO.UserName);

                unitOfWork.Users.Save(user);
                unitOfWork.Complete();

                return Ok(msgModel);
            }
            else
            {
                return StatusCode(statusCode, msgModel);
            }

        }


        [HttpPost()]
        public ActionResult VerifyEmail([FromQuery] string Code)
        {
            MessagesModel messagesModel = new MessagesModel();

            User user = unitOfWork.Users.GetSingle(u => u.VerificationCode == Code);

            if (user is null)
            {
                messagesModel.Message = RegisterErrorMessagesConstants.CodeDosntExist;
                return BadRequest(messagesModel);
            }

            if (user.VerificationCodeExpireDate < DateTime.Now)
            {
                messagesModel.Message = RegisterErrorMessagesConstants.CodeExpired;
                return BadRequest(messagesModel);
            }

            user.IsVerified = true;
            user.VerificationCode = null;

            unitOfWork.Complete();

            messagesModel.Message = AuthConstants.SuccessfullVerification;
            return Ok(messagesModel);
        }


        [HttpPost()]
        public ActionResult Login(UserResponseDTO user)
        {
            MessagesModel msgModel = new MessagesModel();

            User userSelected = unitOfWork.Users.GetSingle(u => u.Email == user.Email);

            if (userSelected is null)
                return Unauthorized();


            if (userSelected.IsVerified == false)
            {
                msgModel.Message = RegisterErrorMessagesConstants.MailNotVerified;
                return Unauthorized(msgModel);
            }

            PasswordHash PasswordHash = new PasswordHash();
            bool isVerified = PasswordHash.VerifyPassword(user.Password, userSelected.PasswordHash);

            if (isVerified)
            {
                if (userSelected.Role is null)
                {
                    msgModel.Message = RegisterErrorMessagesConstants.UsrNotApproved;
                    return BadRequest(msgModel);
                }

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
