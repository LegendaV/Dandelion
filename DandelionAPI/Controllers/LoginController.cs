using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using DandelionAPI.Services;
using Microsoft.AspNetCore.Identity;

namespace DandelionAPI.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private Repo repo;
        public LoginController(Repo repo)
        {
            this.repo = repo;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] UserAuthenticationDto userDto)
        {
            if (userDto.Login == null || userDto.Password == null)
            {
                return BadRequest($"Пользователь не найден");
            }
            var passwordHash = PasswordHash.GetHash(userDto.Password);

            var person = repo.GetAllUsers().FirstOrDefault(p => p.Login == userDto.Login && p.PasswordHash == passwordHash);


            if (person is null)
            {
                return BadRequest("Пользователь не найден");
            }

            var accessToken = DandelionAuthentication.Authenticate(person.Login);
            return new UserDto(person.Id, person.Name, accessToken);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] UserRegisterDto userDto)
        {
            if (repo.GetAllUsers().FirstOrDefault(p => p.Login == userDto.Login) != null)
            {
                return BadRequest("Пользователь с таким логином уже существует");
            }
            if (userDto == null || userDto.UserName == null || userDto.UserName == null || userDto.Password == null)
            {
                return BadRequest("Некорректные данные");
            }
            var user = new User(userDto.UserName, PasswordHash.GetHash(userDto.Password), userDto.UserName);

            repo.AddUser(user);

            var accessToken = DandelionAuthentication.Authenticate(userDto.Login);

            return new UserDto(user.Id, user.Name, accessToken);
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
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}