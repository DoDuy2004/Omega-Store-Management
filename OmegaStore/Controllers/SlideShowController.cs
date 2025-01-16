using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;

namespace OmegaStore.Controllers
{
	public class SlideShowController : Controller
	{
		private readonly StoreDbContext _context;

		public SlideShowController(StoreDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var products = _context.Products.Join(_context.Categories, p => p.CategoryId, c => c.Id, (p, c) => new
			{ Product = p, Category = c });
			return View(products);
		}
		[Route("/DanhSachSanPhamNoiBat")]
		public IActionResult HotSellingProduct()
		{
			var current_time = DateTime.Now;
			DateTime in30day = DateTime.Now.AddDays(-30);
			var hotSellingProduct = _context.Orders.Join(_context.DetailOrders,
				o => o.Id,
				d => d.OrderId,
				(o, d) => new { o.CreatedAt, d.ProductId, d.Quantity })
				//.Where(o => (current_time - o.CreatedAt) <= TimeSpan.FromDays(30))
				.Where(o => o.CreatedAt >= in30day)
				.GroupBy(p => p.ProductId)
				.Select(group => new { ProductId = group.Key, TotalQuantity = group.Sum(p => p.Quantity) })
				.OrderByDescending(p => p.TotalQuantity);

			//var getProduct = _context.Products.Where(p => p.Id == hotSellingProduct.ProductId).FirstOrDefault();
			var getProduct = _context.Products.Join(hotSellingProduct, p => p.Id, h => h.ProductId, (p, h) => new
			{
				Id = p.Id,
				ProductCode = p.ProductCode,
				Name = p.Name,
				Thumbnail = p.Thumbnail,
				Price = p.Price,
				DiscountRate = p.DiscountRate,
				Slug = p.Slug,
				Stock = p.Stock,
				Description = p.Description,
				CategoryId = p.CategoryId,
				Status = p.Status
			});
			var products = getProduct.Join(_context.Categories, p => p.CategoryId, c => c.Id, (p, c) => new
			{ Product = p, Category = c }).Take(10);

			//return RedirectToAction("Detail","Product", new { slug = getProduct.Slug });
			return View("Index", products);
		}
		[Route("/DanhSachSanPhamKhuyenMai")]

		public IActionResult DisCountProducts()
		{
			var products = _context.Products.Join(_context.Categories, p => p.CategoryId, c => c.Id, (p, c) => new
			{ Product = p, Category = c }).Where(pc => pc.Product.DiscountRate >= 25);
			return View("Index", products);
		}
		public IActionResult HarryPotter()
		{
			string slug = "harry-potter";
			return Redirect("../Category/" + slug);
		}

	}
}
