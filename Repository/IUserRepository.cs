using Day_41_FoodOrderingApp.Model;

namespace Day_41_FoodOrderingApp.Repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserByUsername(string username);
        bool UserExists(string username);
        User AddAdmin(User user);
    }
}