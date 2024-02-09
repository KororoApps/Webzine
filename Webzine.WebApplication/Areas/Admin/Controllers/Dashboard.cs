using Microsoft.AspNetCore.Mvc;
using Bogus;


namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.Areas.Admin.ViewModels;
    using Webzine.WebApplication.Areas.Titres.ViewModels;

    [Area("Admin")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return this.View();
        }
    }
}