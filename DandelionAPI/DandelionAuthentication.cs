using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System;

namespace DandelionAPI
{
    public static class DandelionAuthentication
    {
        public static async Task Authenticate(HttpContext context, string name)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, name) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
