using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;
using OmegaStore.Services;

namespace OmegaStore.Components
{
	public class CategoryMenuViewComponent:ViewComponent
	{
		private readonly StoreDbContext _context;

		public CategoryMenuViewComponent(StoreDbContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var categories =  _context.Categories.ToList(); // Lấy danh sách loại sản phẩm
			return View(categories);
		}
	}
}
