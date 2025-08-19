using Day_41_FoodOrderingApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace Day_41_FoodOrderingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/Invoice
        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            var invoices = _invoiceService.GetAllInvoices();
            return Ok(invoices);
        }

        // GET: api/Invoice/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetInvoiceById(int id)
        {
            var invoice = _invoiceService.GetInvoiceById(id);
            if (invoice == null)
                return NotFound($"Invoice with ID {id} not found");

            return Ok(invoice);
        }

        // GET: api/Invoice/by-order/{orderId}
        [HttpGet("by-order/{orderId:int}")]
        public IActionResult GetInvoiceForOrder(int orderId)
        {
            var invoice = _invoiceService.GetInvoiceForOrder(orderId);
            if (invoice == null)
            {
                return NotFound($"No invoice found for order ID {orderId}.");
            }
            return Ok(invoice);
        }
    }
}