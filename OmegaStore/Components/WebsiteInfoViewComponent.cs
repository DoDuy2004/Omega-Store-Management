using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;

namespace OmegaStore.Components
{
	public class WebsiteInfoViewComponent : ViewComponent
	{
		private readonly StoreDbContext _context;

		public WebsiteInfoViewComponent(StoreDbContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var WebsiteInfo = _context.WebsiteInfos.First(w => w.Id == 1);
			return View(WebsiteInfo);
		}
	}
}
