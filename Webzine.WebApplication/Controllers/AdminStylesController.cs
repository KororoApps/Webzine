using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Controllers
{
    public class AdminStylesController : Controller
    {
        public IActionResult AdminStyle()
        {
            return View();
        }
        public IActionResult AdminStyleAjout()
        {
            return View();
        }
        public IActionResult AdminStyleSupression()
        {
            return View();
        }
    }
}
