using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;

namespace OmegaStore.Components
{
	public class LogoInBottombarViewComponent : ViewComponent
	{
		private readonly StoreDbContext _context;

		public LogoInBottombarViewComponent(StoreDbContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var websiteInfo = _context.WebsiteInfos.First(w => w.Id == 1);
			return View(websiteInfo);
		}
	}
}
