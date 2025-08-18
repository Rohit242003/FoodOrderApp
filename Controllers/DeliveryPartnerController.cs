using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace Day_41_FoodOrderingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryPartnerController : ControllerBase
    {
        private readonly IDeliveryPartnerService _partnerService;

        public DeliveryPartnerController(IDeliveryPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        // GET: api/DeliveryPartner
        [HttpGet]
        public IActionResult GetAllPartners()
        {
            var partners = _partnerService.GetAllPartners();
            return Ok(partners);
        }

        // GET: api/DeliveryPartner/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetPartnerById(int id)
        {
            var partner = _partnerService.GetPartnerById(id);
            if (partner == null)
                return NotFound($"DeliveryPartner with ID {id} not found");

            return Ok(partner);
        }

        // POST: api/DeliveryPartner
        [HttpPost]
        public IActionResult AddPartner([FromBody] DeliveryPartner partner)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPartner = _partnerService.CreatePartner(partner);
            return CreatedAtAction(nameof(GetPartnerById), new { id = createdPartner.DeliveryPartnerID }, createdPartner);
        }

        // PUT: api/DeliveryPartner/{id}
        [HttpPut("{id:int}")]
        public IActionResult UpdatePartner(int id, [FromBody] DeliveryPartner partner)
        {
            if (id != partner.DeliveryPartnerID)
                return BadRequest("DeliveryPartner ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_partnerService.GetPartnerById(id) == null)
                return NotFound($"DeliveryPartner with ID {id} not found");

            _partnerService.UpdatePartner(partner);
            return NoContent();
        }

        // DELETE: api/DeliveryPartner/{id}
        [HttpDelete("{id:int}")]
        public IActionResult DeletePartner(int id)
        {
            if (_partnerService.GetPartnerById(id) == null)
                return NotFound($"DeliveryPartner with ID {id} not found");

            _partnerService.DeletePartner(id);
            return NoContent();
        }
    }
}