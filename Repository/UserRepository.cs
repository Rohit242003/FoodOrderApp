using Day_41_FoodOrderingApp.Data;
using Day_41_FoodOrderingApp.Model;
using System.Linq;

namespace Day_41_FoodOrderingApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextFoodApp _context;

        public UserRepository(DbContextFoodApp context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public bool UserExists(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public User AddAdmin(User user)
        {
            
            user.Role = Role.Admin;
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}