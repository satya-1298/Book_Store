using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressBusiness addressBusiness;
        public AddressController(IAddressBusiness addressBusiness)
        {
            this.addressBusiness = addressBusiness;
        }
        [Authorize]
        [HttpPost]
        [Route("AddAddress")]
        public IActionResult CreateAddress(AddressModel addressModel)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
            var result=addressBusiness.AddAddress(addressModel, id);
            if (result !=null)
            {

                return this.Ok(new { success = true, message = "Address added Successfully", data = result });
            }

            return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });

        }
        [Authorize]
        [HttpPut]
        [Route("UpdateAddress")]
        public IActionResult UpdateAddress(AddressModel addressModel,int id)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
            var result= addressBusiness.UpdateAddress(id,userId, addressModel);
            if (result != null)
            {

                return this.Ok(new { success = true, message = "Address Updated Successfully", data = result });
            }

            return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });

        }
        [Authorize]
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteAddress(int id)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
            var result = addressBusiness.RemoveAddress(id,userId);
            if (result != null)
            {

                return this.Ok(new { success = true, message = "Address deleted Successfully", data = result });
            }

            return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });

        }
        [Authorize]
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Retrive()
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
            var result =addressBusiness.GetAllAddresses(userId);
            if (result != null)
            {

                return this.Ok(new { success = true, message = "Successfully", data = result });
            }

            return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });

        }
    }
}
