using LogisticsDataCore.Constants;
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

        [HttpPost(), Authorize(Roles = "Admin")]
        public ActionResult<StoreRequestDTO> AddStore([FromBody]StoreRequestDTO storeDto)
        {
            Store storeWithStoreName = unitOfWork.Stores.GetSingle(s => s.StoreName == storeDto.StoreName);
            List<Governorate> governorates = unitOfWork.Governorates.GetAll();

            StoreCreationValidator storeCreationValidator = new StoreCreationValidator();
            StoreDTOsConverter converter = new StoreDTOsConverter();
            int StatusCode = 0;

            MessagesModel errorsModel = storeCreationValidator.ValidateStore(storeDto, storeWithStoreName, governorates, out StatusCode);

            if (StatusCode == 400)
            {
                return BadRequest(errorsModel);
            }

            User user = unitOfWork.Users.GetSingle(u => u.UserName == storeDto.StoreManagerName);

            Governorate gov = unitOfWork.Governorates.GetSingle(g => g.GovernorateName == storeDto.StoreGovernorateName);

            Store store = converter.ConvertStoreRequestDTOToStore(storeDto, user.UserID, gov.GovernorateID);

            unitOfWork.Stores.Save(store);
            unitOfWork.Complete();

            return Ok(storeDto);
        }


        [HttpGet(), Authorize()]
        public ActionResult<List<StoreRequestDTO>> GetStores()
        {
            StoreDTOsConverter dTOsConverter = new StoreDTOsConverter();
            List<StoreRequestDTO> storeRequestDTOs = new List<StoreRequestDTO>();

            List<Store> stores = unitOfWork.Stores.GetAll();

            foreach(Store store in stores)
            {

                User user = unitOfWork.Users.GetSingle(u => u.UserID == store.StoreManagerID);
                Governorate gov = unitOfWork.Governorates.GetSingle(g => g.GovernorateID == store.StoreGovernorateID);

                storeRequestDTOs.Add(dTOsConverter.ConvertStoreToStoreDto(store, user.UserName, gov.GovernorateName));
            }

            return Ok(storeRequestDTOs);
        }


        [HttpDelete, Authorize(Roles = "Admin")]
        public ActionResult DeleteStore([FromQuery] int ID)
        {
            MessagesModel messagesModel = new MessagesModel();

            unitOfWork.Stores.Delete(s => s.StoreID == ID);
            int count = unitOfWork.Complete();

            if (count == 0)
            {
                messagesModel.Message = StoreMessages.CantDeleteStore;

                return BadRequest(messagesModel);
            }

            messagesModel.Message = StoreMessages.StoreDeleted;
            return Ok(messagesModel);
        }

    }
}
