using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day_41_FoodOrderingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound(); // Returns HTTP 404 Not Found
            }

            return Ok(order); // Returns HTTP 200 OK
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            var createdOrder = await _orderService.CreateNewOrderAsync(order);

            // Returns HTTP 201 Created with a link to the new resource
            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.OrderId }, createdOrder);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order orderToUpdate)
        {
            if (id != orderToUpdate.OrderId)
            {
                return BadRequest("ID mismatch between URL and request body.");
            }

            // Note: You might add a check here to see if the order exists first
            await _orderService.UpdateOrderAsync(orderToUpdate);

            return NoContent(); // Returns HTTP 204 No Content
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var success = await _orderService.DeleteOrderAsync(id);

            if (!success)
            {
                return NotFound(); // Returns HTTP 404 Not Found
            }

            return NoContent(); // Returns HTTP 204 No Content
        }
    }
}