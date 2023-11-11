using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Interface;
using System.Linq;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailsBusiness orderDetail;
        public OrderDetailController(IOrderDetailsBusiness orderDetail)
        {
            this.orderDetail = orderDetail;
        }
        [Authorize]
        [HttpPost]
        [Route("OrderBook/{bookId}")]
        public IActionResult CreateOrder(CreateOrderDetails createOrderDetails,int bookId)
        {
            try
            {
                var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                
                var result = orderDetail.CreateOrder(createOrderDetails, userId, bookId);
                if (result != null)
                {

                    return this.Ok(new { success = true, message = "Order added Successfully", data = result });
                }

                return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });
            }
            catch
            {
                return null;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("UpdateOrder/{bookId}/{orderDetailId}")]
        public IActionResult UpdateOrder(CreateOrderDetails createOrderDetails,int bookId,int orderDetailId)
        {

            try
            {
                var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

                var result = orderDetail.UpdateOrder(createOrderDetails, userId, bookId,orderDetailId);
                if (result != null)
                {

                    return this.Ok(new { success = true, message = "Order Updated Successfully", data = result });
                }

                return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });
            }
            catch
            {
                return null;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("GetAllOrders")]
        public IActionResult GetOrder()
        {
            try
            {
                var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = orderDetail.GetAllOrders(userId);
                if(result != null)
                {
                    return this.Ok(new { success = true, message = " Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });
                }
            }
            catch 
            { 
                return null;
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("Delete Order/{orderId}")]
        public IActionResult OrderRemove(int orderId)
        {
            try
            {
                var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = orderDetail.RemoveOrder(orderId, userId);
                if(result != null)
                {
                    return this.Ok(new { success = true, message = "Order Removed Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
