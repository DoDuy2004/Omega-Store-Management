using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly StoreDbContext _context;

        public ProductController(StoreDbContext context)
        {
            _context = context;
        }

        //Trang Danh sách sản phẩm
        public IActionResult Index()
        {
            var products = _context.Products.ToList(); // Lấy tất cả các sản phẩm từ cơ sở dữ liệu
            return View(products); // Truyền danh sách sản phẩm vào View
        }

        //Trang Chi tiết sản phẩm
        public IActionResult Detail(int id)
        {
            var product = _context.Products
                             .FirstOrDefault(p => p.Id == id); // Lấy sản phẩm theo ProductId

            if (product == null)
            {
                return NotFound(); // Nếu sản phẩm không tồn tại, trả về 404
            }

            return View(product); // Truyền sản phẩm vào View
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
