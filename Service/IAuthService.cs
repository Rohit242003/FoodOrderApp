using Day_41_FoodOrderingApp.Model;

namespace Day_41_FoodOrderingApp.Service
{
    public interface IAuthService
    {
        User Register(RegisterViewModel model);
        LoginResponseViewModel Login(LoginViewModel model);
        User CreateAdmin(RegisterViewModel model);
    }
}