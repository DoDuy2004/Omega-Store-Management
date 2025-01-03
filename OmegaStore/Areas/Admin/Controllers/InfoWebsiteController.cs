using Microsoft.AspNetCore.Mvc;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InfoWebsiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
