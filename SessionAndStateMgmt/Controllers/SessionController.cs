using Microsoft.AspNetCore.Mvc;

namespace SessionAndStateMgmt.Controllers
{
    public class SessionController : Controller
    {
        public const string SessionKeyName = "_Name";
        public const string SessionKeyAge = "_Age";

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "Alvin");
                HttpContext.Session.SetInt32(SessionKeyAge, 27);
            }

            var name = HttpContext.Session.GetString(SessionKeyName);
            var age = HttpContext.Session.GetInt32(SessionKeyAge).ToString();


            return View(model: new { Name = name, Age = age });
        }

        public IActionResult Secret()
        {
            var name = HttpContext.Session.GetString(SessionKeyName);
            var age = HttpContext.Session.GetInt32(SessionKeyAge).ToString();

            return View(model: new { Name = name, Age = age });
        }
    }
}
