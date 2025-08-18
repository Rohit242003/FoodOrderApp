using Day_41_FoodOrderingApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace Day_41_FoodOrderingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        // GET: api/PaymentMethod
        [HttpGet]
        public IActionResult GetAllPaymentMethods()
        {
            var paymentMethods = _paymentMethodService.GetAllPaymentMethods();
            return Ok(paymentMethods);
        }

        // GET: api/PaymentMethod/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetPaymentMethodById(int id)
        {
            var paymentMethod = _paymentMethodService.GetPaymentMethodById(id);
            if (paymentMethod == null)
                return NotFound($"PaymentMethod with ID {id} not found");

            return Ok(paymentMethod);
        }
    }
}