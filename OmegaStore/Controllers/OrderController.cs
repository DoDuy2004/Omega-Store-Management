using Microsoft.AspNetCore.Mvc;

namespace OmegaStore.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
