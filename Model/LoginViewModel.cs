using System.ComponentModel.DataAnnotations;

namespace Day_41_FoodOrderingApp.Model
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}