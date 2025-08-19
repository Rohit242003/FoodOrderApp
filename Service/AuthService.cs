using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Day_41_FoodOrderingApp.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public User Register(RegisterViewModel model)
        {
            if (_userRepository.UserExists(model.Username))
            {
                return null; // Username already exists
            }

          

            var user = new User
            {
                Username = model.Username,
                Password = model.Password, 
                Role = Role.User
            };

            return _userRepository.AddUser(user);
        }

        public LoginResponseViewModel Login(LoginViewModel model)
        {
            var user = _userRepository.GetUserByUsername(model.Username);

            
            if (user == null || user.Password != model.Password)
            {
                return null; // Failed login
            }

            var token = CreateToken(user);

            return new LoginResponseViewModel
            {
                UserId = user.UserId,
                Username = user.Username,
                Role = user.Role,
                Token = token
            };
        }

       

        private string CreateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public User CreateAdmin(RegisterViewModel model)
        {
            if (_userRepository.UserExists(model.Username))
            {
                return null; 
            }

            

            var user = new User
            {
                Username = model.Username,
                Password = model.Password 
            };

            
            return _userRepository.AddAdmin(user);
        }
    }
}