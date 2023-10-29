using LogisticsDataCore.DTOs;
using LogisticsDataCore.DTOsConverter;
using LogisticsDataCore.Interfaces.IUnitOfWork;
using LogisticsDataCore.Models;
using LogisticsEntity.ModelsFieldsValidator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsProject.Controllers
{

    [Route("api/[controller]/[action]")]
    public class StoreController(IUnitOfWork unitOfWork) : ControllerBase
    {

        [HttpPost(), Authorize()]
        public ActionResult<StoreRequestDTO> AddStore(StoreRequestDTO storeDto)
        {
            Store storeWithStoreName = unitOfWork.Stores.Get(s => s.StoreName == storeDto.StoreName);
            List<Governorate> governorates = unitOfWork.Governorates.GetAll();

            StoreCreationValidator storeCreationValidator = new StoreCreationValidator();
            DTOsConverter converter = new DTOsConverter();
            int StatusCode = 0;

            ErrorsModel errorsModel = storeCreationValidator.ValidateStore(storeDto, storeWithStoreName, governorates, out StatusCode);

            if (StatusCode == 400)
            {
                return BadRequest(errorsModel);
            }

            Store store = converter.ConvertStoreRequestDTOToStore(storeDto);

            unitOfWork.Stores.Save(store);
            unitOfWork.Complete();

            return Ok(storeDto);
        }
    }
}
