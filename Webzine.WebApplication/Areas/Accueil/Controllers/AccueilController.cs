using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Areas.Accueil.Controllers
{
    public class AccueilController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
