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
        [HttpGet("login")]
        public async void GetLoginPage()
        {
            Response.ContentType = "text/html; charset=utf-8";
            string loginForm = @"<!DOCTYPE html>
                <html>
                <head>
                    <meta charset='utf-8' />
                    <title>Dandelion</title>
                </head>
                <body>
                    <h2>Login Form</h2>
                    <form method='post'>
                        <p>
                            <label>Email</label><br />
                            <input name='email' />
                        </p>
                        <p>
                            <label>Password</label><br />
                            <input type='password' name='password' />
                        </p>
                        <input type='submit' value='Login' />
                    </form>
                </body>
                </html>";
            await Response.WriteAsync(loginForm);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login()
        {
            var form = Request.Form;
            if (!form.ContainsKey("email") || !form.ContainsKey("password"))
            {
                return BadRequest("Пользователь не найден");
            }
            var name = form["email"];
            var passwordHash = form["password"].GetHashCode();

            var person = Repo.GetAllUsers().FirstOrDefault(p => p.Name == name && p.PasswordHash == passwordHash);

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
            Repo.AddUser(user);
            await DandelionAuthentication.Authenticate(HttpContext, user.Name);
            UserDto result = user;
            return result;
        }

        [HttpPost("test")]
        public async Task<ActionResult> test([FromBody] UserDto user)
        {
            return Ok(user.Name);
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