using LogisticsDataCore.Interfaces.IUnitOfWork;
using LogisticsDataCore.Models;
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

    }
}

