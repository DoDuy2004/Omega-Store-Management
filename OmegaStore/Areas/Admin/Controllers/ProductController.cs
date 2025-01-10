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
            
            List<Review> reviews = _context.Reviews.Where(p => p.ProductId == id).ToList();
            if (product == null)
            {
                return NotFound(); // Nếu sản phẩm không tồn tại, trả về 404
            }
            ViewBag.Reviews = reviews;
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
        public IActionResult DeleteReview(string email, int id)
        {
            var getReview = _context.Reviews.FirstOrDefault(p => p.Email == email && p.ProductId == id);
            if (getReview != null)
            {
                _context.Reviews.Remove(getReview);
                _context.SaveChanges();
                TempData["success"] = "Xóa đánh giá thành công";
            }

            var product = _context.Products.FirstOrDefault(p => p.Id == id); // Lấy sản phẩm theo ProductId

            List<Review> reviews = _context.Reviews.Where(p => p.ProductId == id).ToList();
            ViewBag.Reviews = reviews;
            return View("Detail", product); // Truyền sản phẩm vào View            
        }
    }
}
