using LogisticsDataCore.Constants;
using LogisticsDataCore.Interfaces.IUnitOfWork;
using LogisticsDataCore.Models;
using LogisticsDataCore.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController(IUnitOfWork unitOfWork) : ControllerBase
    {

        [HttpGet(), Authorize(Roles = "Admin")]
        public ActionResult<List<User>> GetUsersByRole([FromQuery]string role)
        {
            return Ok(unitOfWork.Users.GetManyWhere(u => u.Role == role));
        }

        [HttpDelete()]
        public ActionResult DeleteUserByEmail([FromBody] DeleteUserByEmailModel emailModel)
        { 
            MessagesModel messageModel = new MessagesModel();
            unitOfWork.Users.DeleteSingle(e=>e.Email == emailModel.Email);
           int count= unitOfWork.Complete();
            if(count==0)
            {
                messageModel.Message = UserMessages.invalidUserEmail;
                return BadRequest(messageModel);
            }
            messageModel.Message = UserMessages.validUserEmail;
            return Ok(messageModel);
        }
        [HttpDelete]
        public ActionResult<int> DeleteAllUsers()
        {
            return Ok(unitOfWork.Users.DeleteAll());
        }

    }
}

