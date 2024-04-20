using LogisticsDataCore.Constants;
using LogisticsDataCore.Interfaces.IUnitOfWork;
using LogisticsDataCore.Tables;
using LogisticsEntity.DTOsConverter;
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


        [HttpGet(), Authorize(Roles = RoleConstants.AdminRole)]
        public ActionResult<List<Role>> GetRoles()
        {
            List<Role> roles = unitOfWork.Roles.GetAll();

            return Ok(RoleDTOConverter.ConvertRolesToRolesDto(roles));
        }


        [HttpGet(), Authorize()]
        public ActionResult<List<Governorate>> GetGovernorates()
        {
            return Ok(unitOfWork.Governorates.GetAll());
        }
    }
}
