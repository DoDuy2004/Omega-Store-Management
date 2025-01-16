using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly StoreDbContext _context;

        public HomeController(StoreDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("AdminUsername");
            if (username == null)
            {
                return RedirectToAction("LoginView", "Account");
            }
            ViewData["AccountName"] = username;
            return View();
        }

        public IActionResult Roles()
        {
            var roles = _context.Roles.ToList(); // Lấy tất cả các danh mục từ cơ sở dữ liệu
            return View(roles); // Truyền danh sách danh mục vào View
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
