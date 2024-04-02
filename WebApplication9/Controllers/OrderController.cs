using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using WebApplication9.Services.Orders;
using Microsoft.AspNetCore.Authorization;


namespace WebAplication7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }


        [HttpPost]
        public async Task<ActionResult<Order>> Post(Order order)
        {
            await _orderService.AddOrder(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            await _orderService.UpdateOrder(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteOrder(id);
            return NoContent();
        }
    }
}

