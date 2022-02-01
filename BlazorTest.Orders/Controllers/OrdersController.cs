namespace BlazorTest.Orders.Controllers
{
    using BlazorTest.Orders.Application.Aggregates.Orders.Commands.CreateOrderCommand;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetOrders()
        {
            return this.Ok(Guid.NewGuid());
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetOrder([FromQuery] string orderId)
        {
            return this.Ok(new Guid(orderId));
        }

        [HttpPost]
        [Route("orders/new-order")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            return this.Ok(Guid.NewGuid());
        }
    }
}
