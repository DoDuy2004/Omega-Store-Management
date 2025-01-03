using Microsoft.AspNetCore.Mvc;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
