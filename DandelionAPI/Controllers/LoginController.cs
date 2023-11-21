using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IResult> Login(string? returnUrl)
        {
            var form = Request.Form;
            if (!form.ContainsKey("email") || !form.ContainsKey("password"))
            {
                return Results.BadRequest("Email и/или пароль не установлены");
            }
            var name = form["email"];
            var password = form["password"];

            var person = Repo.GetAllUsers().FirstOrDefault(p => p.Name == name && p.Password == password);

            if (person is null)
            {
                return Results.Unauthorized();
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Name) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return Results.Redirect(returnUrl ?? "/");
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