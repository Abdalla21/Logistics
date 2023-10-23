using LogisticsDataCore.Models;
using LogisticsDataCore.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsProject.Controllers
{
    public class InfoController(IGenericRepository<Role> RolesRepository,
        IGenericRepository<Governorate> GovernoratesRepository,
        IGenericRepository<Category> CategoriesRepository) : ControllerBase
    {

        [HttpGet(), Authorize(Roles = "Admin")]
        public ActionResult<List<Role>> GetCategories()
        {
            return Ok(CategoriesRepository.GetAll());
        }


        [HttpGet(), Authorize(Roles = "Admin")]
        public ActionResult<List<Role>> GetRoles()
        {
            return Ok(RolesRepository.GetAll());
        }


        [HttpGet(), Authorize(Roles = "Admin")]
        public ActionResult<List<Role>> GetGovernorates()
        {
            return Ok(GovernoratesRepository.GetAll());
        }
    }
}
