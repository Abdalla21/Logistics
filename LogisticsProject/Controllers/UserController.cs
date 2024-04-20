using LogisticsDataCore.Constants;
using LogisticsDataCore.DTOs.UserDTOs;
using LogisticsDataCore.Interfaces.IUnitOfWork;
using LogisticsDataCore.Models;
using LogisticsDataCore.Tables;
using LogisticsEntity.DTOsConverter;
using LogisticsEntity.ModelsFieldsValidator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController(IUnitOfWork unitOfWork) : ControllerBase
    {

        [HttpGet(), Authorize(Roles = RoleConstants.AdminRole)]
        public ActionResult<List<User>> GetUsersByRole([FromQuery] string role)
        {
            List<User> usersByRole = unitOfWork.Users.GetManyWhere(u => u.Role == role);

            return Ok(UserDTOConverter.ConvertUsersToUsersDTO(usersByRole));
        }


        [HttpDelete()]
        public ActionResult<MessagesModel> DeleteUserByEmail([FromBody] DeleteUserByEmailModel emailModel)
        {
            MessagesModel messageModel = new MessagesModel();
            unitOfWork.Users.DeleteSingle(e => e.Email == emailModel.Email);
            int count = unitOfWork.Complete();
            if (count == 0)
            {
                messageModel.Message = UserMessages.invalidUserEmail;
                return BadRequest(messageModel);
            }
            messageModel.Message = UserMessages.validUserEmail;
            return Ok(messageModel);
        }


        [HttpGet(), Authorize(Roles = RoleConstants.AdminRole)]
        public ActionResult<List<UserDTO>> GetNotAcceptedUsers()
        {
            List<User> notAcceptedUsers = unitOfWork.Users.GetManyWhere(u => u.IsVerified && u.Role == null && u.IsAccepted == null);

            return Ok(UserDTOConverter.ConvertUsersToUsersDTO(notAcceptedUsers));
        }


        [HttpGet(), Authorize(Roles = RoleConstants.AdminRole)]
        public ActionResult AcceptUser(bool IsAccepted, string Role, string Email)
        {
            UserModelFieldsValidator validator = new UserModelFieldsValidator();

            if (!validator.IsValidRole(Role, Email))
                return BadRequest();

            User user = unitOfWork.Users.GetSingle(u => u.Email == Email);

            if (user is null)
            {
                return NotFound();
            }

            user.IsAccepted = IsAccepted.ToString();
            user.Role = Role;
            unitOfWork.Complete();

            return Ok();
        }


        [HttpPost(), Authorize(Roles = RoleConstants.AdminRole)]
        public ActionResult EditUserRole(string Role, string Email)
        {
            UserModelFieldsValidator validator = new UserModelFieldsValidator();

            if (!validator.IsValidRole(Role, Email))
                return BadRequest();

            User user = unitOfWork.Users.GetSingle(u => u.Email == Email);

            if (user is null)
            {
                return NotFound();
            }

            user.Role = Role;
            unitOfWork.Complete();

            return Ok();
        }


        // Need to implement editing for the current user if he wants to edit his info
        // Need to get his email from the JWT Token
        [HttpPost(), Authorize()]
        public ActionResult EditCurrentUserInfo()
        {
            return Ok();
        }


    }
}
