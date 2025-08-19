using System.ComponentModel.DataAnnotations;

namespace Day_41_FoodOrderingApp.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; } 

        public Role Role { get; set; } = Role.User;
    }
}