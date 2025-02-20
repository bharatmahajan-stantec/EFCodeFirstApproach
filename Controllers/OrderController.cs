using EFCodeFirst.DTO;
using EFCodeFirst.EntityClasses;
using EFCodeFirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCodeFirst.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/orders")]
    [ApiController]
    [ControllerName("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<ApiResponse<IEnumerable<Order>>> GetAllOrders()
        {
            var response = _orderService.GetAllOrders();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{orderId}")]
        public ActionResult<ApiResponse<Order>> GetOrderById(int orderId)
        {
            var response = _orderService.GetOrderById(orderId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public ActionResult<ApiResponse<Order>> AddOrder([FromBody] Order order)
        {
            var response = _orderService.AddOrder(order);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{orderId}")]
        public ActionResult<ApiResponse<Order>> UpdateOrder(int orderId, [FromBody] OrderDTO order)
        {
            var response = _orderService.UpdateOrder(orderId, order);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{orderId}")]
        public ActionResult<ApiResponse<bool>> DeleteOrder(int orderId)
        {
            var response = _orderService.DeleteOrder(orderId);
            return StatusCode(response.StatusCode, response);
        }
    }
}
