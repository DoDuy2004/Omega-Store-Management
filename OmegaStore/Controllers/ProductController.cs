using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmegaStore.Models;

namespace OmegaStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly StoreDbContext _context;

        public ProductController(StoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("[controller]/{slug}", Name = "ProductDetail")]
        public IActionResult Detail(string slug)
        {
            var products = _context.Products;
            var product = products
                .Include(p => p.ProductsImages)
                .Include(p => p.Reviews)
                .FirstOrDefault(p => p.Slug == slug);

            ViewBag.product = product;

            if (product != null)
                ViewBag.relatedProducts = products
                    .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Comment(Review review, int rating)
        {
            var reviews = _context.Reviews;
            review.Rating = rating;
            reviews.Add(review);

            var product = _context.Products.First(p => p.Id == review.ProductId);

            _context.SaveChanges();

            return RedirectToRoute("ProductDetail", new { slug = product.Slug });
        }
    }
}
