using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmegaStore.Models;
using OmegaStore.Models.ViewModels;
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

			var categories = _context.Categories.ToList();
			if(!categories.Any()||categories==null)
			{
				return NotFound();
			}


			return PartialView("_NavbarPartial", categories);
		}
		[HttpGet("[controller]/{slug}")]
		public IActionResult ListProduct(string slug)
		{
			var cate = _context.Categories.ToList();

			if (cate == null || !cate.Any())
			{
				return NotFound();
			}
			var prod = _context.Products.ToList();
            if (prod == null || !prod.Any())
            {
                return NotFound();
			}
				var product = _context.Products
			.Include(p => p.ProductsImages) // Lấy hình ảnh liên quan
			.Include(p => p.Reviews) // Lấy đánh giá của sản phẩm
			.Where(p => p.Category.Slug == slug).Select(p => new CategoryProductListViewModel
				{
					Id = p.Id,
					Name = p.Name,
					Price = p.Price,
					Slug = p.Slug,
					DiscountRate = p.DiscountRate,
					Img = p.Thumbnail,
					Views = p.Stock,
					Rating = p.Reviews.Any() ? p.Reviews.FirstOrDefault().Rating : 4
				}).ToList();

			if (product == null || !product.Any())
            {
                return NotFound();
            }

            var ProductCategoryModel = new ProductCategoryModel
			{
				Products = prod,
				CategoryProducts = product
			};
				ViewBag.ListCate = cate;
			ViewBag.Slug = slug;

			return View(ProductCategoryModel);
		}
	}
}
