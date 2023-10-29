using LogisticsDataCore.Interfaces.IRepositories;
using LogisticsDataCore.Interfaces.IUnitOfWork;
using LogisticsDataCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsProject.Controllers
{

    [Route("api/[controller]/[action]")]
    public class InfoController(IUnitOfWork unitOfWork) : ControllerBase
    {

        [HttpGet(), Authorize()]
        public ActionResult<List<Category>> GetCategories()
        {
            return Ok(unitOfWork.Categories.GetAll());
        }


        [HttpGet(), Authorize(Roles = "Admin")]
        public ActionResult<List<Role>> GetRoles()
        {
            return Ok(unitOfWork.Roles.GetAll());
        }


        [HttpGet(), Authorize()]
        public ActionResult<List<Governorate>> GetGovernorates()
        {
            return Ok(unitOfWork.Governorates.GetAll());
        }
    }
}
