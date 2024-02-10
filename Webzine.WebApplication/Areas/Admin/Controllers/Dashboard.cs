using Microsoft.AspNetCore.Mvc;
using Bogus;


namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return this.View();
        }
    }
}