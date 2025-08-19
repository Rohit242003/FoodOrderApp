using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Service;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;

namespace Day_41_FoodOrderingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _authService.Register(model);

            if (user == null)
            {
                return BadRequest("Username is already taken.");
            }

            return Ok(new { message = "Registration successful" });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = _authService.Login(model);

            if (response == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(response);
        }

       
        [HttpPost("create-admin")]
        [Authorize(Roles = "Admin")] 
        public IActionResult CreateAdmin(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adminUser = _authService.CreateAdmin(model);

            if (adminUser == null)
            {
                return BadRequest("Username is already taken.");
            }

            return Ok(new { message = "Admin user created successfully." });
        }
    }
}