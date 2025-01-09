using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmegaStore.Models;
using OmegaStore.Services;

namespace OmegaStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly StoreDbContext _context;
        public CategoryController(StoreDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var product = _context.Categories.ToList();
            ViewBag.Product = product;

            return View();
        }
		public IActionResult ListProduct(string slugCategory)
		{
            var cate=_context.Categories.ToList();
			var product = _context.Products.Include(p => p.ProductsImages)
				.Include(p => p.Reviews).Where(p => p.Category.Slug == slugCategory).ToList();
            
            ViewBag.ListProd=product;
			return View(cate);
		}
	}
}
