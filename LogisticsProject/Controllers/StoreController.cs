using LogisticsDataCore.DTOs;
using LogisticsDataCore.DTOsConverter;
using LogisticsDataCore.Interfaces.IUnitOfWork;
using LogisticsDataCore.Models;
using LogisticsEntity.ModelsFieldsValidator;
using LogisticsEntity.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsProject.Controllers
{

    [Route("api/[controller]/[action]")]
    public class StoreController(IUnitOfWork unitOfWork) : ControllerBase
    {

        [HttpPost(), Authorize(Roles = "Admin")]
        public ActionResult<StoreRequestDTO> AddStore([FromBody]StoreRequestDTO storeDto)
        {
            Store storeWithStoreName = unitOfWork.Stores.Get(s => s.StoreName == storeDto.StoreName);
            List<Governorate> governorates = unitOfWork.Governorates.GetAll();

            StoreCreationValidator storeCreationValidator = new StoreCreationValidator();
            DTOsConverter converter = new DTOsConverter();
            int StatusCode = 0;

            MessagesModel errorsModel = storeCreationValidator.ValidateStore(storeDto, storeWithStoreName, governorates, out StatusCode);

            if (StatusCode == 400)
            {
                return BadRequest(errorsModel);
            }

            User user = unitOfWork.Users.Get(u => u.UserName == storeDto.StoreManagerName);

            Governorate gov = unitOfWork.Governorates.Get(g => g.GovernorateName == storeDto.StoreGovernorateName);

            Store store = converter.ConvertStoreRequestDTOToStore(storeDto, user.UserID, gov.GovernorateID);

            unitOfWork.Stores.Save(store);
            unitOfWork.Complete();

            return Ok(storeDto);
        }
    }
}
