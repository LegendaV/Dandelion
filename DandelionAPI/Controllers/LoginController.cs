using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace DandelionAPI.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private AppDbContext appDbContext;
        public LoginController(AppDbContext dbContext)
        {
            appDbContext = dbContext;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] UserAuthenticationDto userDto)
        {
            if (userDto.Email == null || userDto.Password == null)
            {
                return BadRequest($"Пользователь не найден");
            }
            var passwordHash = userDto.Password.GetHashCode();

            Console.WriteLine(appDbContext.Users);

            var person = appDbContext.Users.FirstOrDefault(p => p.Name == userDto.Email && p.PasswordHash == passwordHash);
            //var person = Repo.GetAllUsers().FirstOrDefault(p => p.Name == userDto.Email && p.PasswordHash == passwordHash);

            if (person is null)
            {
                return BadRequest("Пользователь не найден");
            }

            await DandelionAuthentication.Authenticate(HttpContext, person.Name);
            UserDto result = person;
            return result;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] UserRegisterDto userDto)
        {
            //username passwod email
            if (userDto == null || userDto.UserName == null || userDto.Email == null || userDto.Password == null)
            {
                return BadRequest("Некорректные данные");
            }
            var user = new User(userDto.UserName, userDto.Password.GetHashCode(), userDto.Email);
            

            appDbContext.Users.AddRange(user);
            appDbContext.SaveChanges();

            // получаем объекты из бд и выводим на консоль
            var users = appDbContext.Users.ToList();
            Console.WriteLine("Users list:");
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name}");
            }
            
            //Repo.AddUser(user);
            await DandelionAuthentication.Authenticate(HttpContext, user.Name);
            UserDto result = user;
            return result;
        }

        [Authorize]
        [HttpGet("logout")]
        public async Task<ActionResult> LogoutAsync()
        {
            try
            {
                await HttpContext.SignOutAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}