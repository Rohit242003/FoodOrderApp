using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Day_41_FoodOrderingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        // GET: api/MenuItem
        [HttpGet]
        public IActionResult GetAllMenuItems()
        {
            var menuItems = _menuItemService.GetAllMenuItems();
            return Ok(menuItems);
        }

        // GET: api/MenuItem/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetMenuItemById(int id)
        {
            var menuItem = _menuItemService.GetMenuItemById(id);
            if (menuItem == null)
                return NotFound($"MenuItem with ID {id} not found");

            return Ok(menuItem);
        }

        // POST: api/MenuItem
        [HttpPost]
        public IActionResult AddMenuItem([FromBody] MenuItem menuItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdItem = _menuItemService.CreateMenuItem(menuItem);
            return CreatedAtAction(nameof(GetMenuItemById), new { id = createdItem.MenuId }, createdItem);
        }

        // PUT: api/MenuItem/{id}
        [HttpPut("{id:int}")]
        public IActionResult UpdateMenuItem(int id, [FromBody] MenuItem menuItem)
        {
            if (id != menuItem.MenuId)
                return BadRequest("MenuItem ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_menuItemService.GetMenuItemById(id) == null)
                return NotFound($"MenuItem with ID {id} not found");

            _menuItemService.UpdateMenuItem(menuItem);
            return NoContent();
        }

        // DELETE: api/MenuItem/{id}
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteMenuItem(int id)
        {
            if (_menuItemService.GetMenuItemById(id) == null)
                return NotFound($"MenuItem with ID {id} not found");

            _menuItemService.DeleteMenuItem(id);
            return NoContent();
        }
    }
}