using Microsoft.AspNetCore.Mvc;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PurchaseOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
