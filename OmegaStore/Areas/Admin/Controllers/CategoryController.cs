using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly StoreDbContext _context;

        public CategoryController(StoreDbContext context)
        {
            _context = context;
        }
        //Trang Danh sách Danh mục
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList(); // Lấy tất cả các danh mục từ cơ sở dữ liệu
            return View(categories); // Truyền danh sách danh mục vào View
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
