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
        private readonly IOrderDetailRepo orderDetail;
        public OrderDetailController(IOrderDetailRepo orderDetail)
        {
            this.orderDetail = orderDetail;
        }
        [Authorize]
        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDetails createOrderDetails)
        {
            try
            {
                var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var bookId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "BookId").Value);
                var result = orderDetail.CreateOrder(createOrderDetails, userId, bookId);
                if (result != null)
                {
                    return (IActionResult)result;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
