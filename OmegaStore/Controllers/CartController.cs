using Microsoft.AspNetCore.Mvc;

namespace OmegaStore.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
