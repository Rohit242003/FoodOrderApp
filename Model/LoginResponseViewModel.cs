namespace Day_41_FoodOrderingApp.Model
{
    public class LoginResponseViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; } // The JWT
    }
}