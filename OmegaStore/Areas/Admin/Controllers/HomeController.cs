using Microsoft.AspNetCore.Mvc;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult Component()
        {
            return View();
        }
    }
}
