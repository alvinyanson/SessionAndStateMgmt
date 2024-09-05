using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SessionAndStateMgmt.Controllers
{
    public class CookieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, "Alvin"),
                new Claim(ClaimTypes.MobilePhone, "1234567890"),
                new Claim(ClaimTypes.Email, "nV9oJ@example.com"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            var user = HttpContext.User;

            var result = new
            {
                Id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Name = user.FindFirst(ClaimTypes.Name)?.Value,
                Phone = user.FindFirst(ClaimTypes.MobilePhone)?.Value,
                Email = user.FindFirst(ClaimTypes.Email)?.Value,
                Role = user.FindFirst(ClaimTypes.Role)?.Value
            };

            return View(result);
        }
    }
}
