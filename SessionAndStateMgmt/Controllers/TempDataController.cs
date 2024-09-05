using Microsoft.AspNetCore.Mvc;
using SessionAndStateMgmt.Models;

namespace SessionAndStateMgmt.Controllers
{
    public class TempDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CommentForm request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            TempData["SuccessMsg"] = "Form submitted successfully";

            ModelState.Clear();

            return RedirectToAction(nameof(Index));
        }
    }
}
