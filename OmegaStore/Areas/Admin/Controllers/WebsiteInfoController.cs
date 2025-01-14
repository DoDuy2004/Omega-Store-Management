using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmegaStore.Models;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WebsiteInfoController : Controller
    {
        private readonly StoreDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public WebsiteInfoController(StoreDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var WebsiteInfo = _context.WebsiteInfos.First(w => w.Id == 1);
            return View(WebsiteInfo);
        }

        [HttpPost]
        public IActionResult Update(WebsiteInfo websiteInfo, bool logoIsDeleted)
        {
			if (ModelState.IsValid)
			{
				// Lấy đường dẫn đến thư mục wwwroot/img
				string imgDir = Path.Combine(_webHostEnvironment.WebRootPath, "img");

				// Xóa ảnh cũ nếu cần
				if (logoIsDeleted || websiteInfo.LogoUpload != null)
				{
					if (!string.IsNullOrEmpty(websiteInfo.Logo))
					{
						string oldImgPath = Path.Combine(imgDir, websiteInfo.Logo);
						if (System.IO.File.Exists(oldImgPath))
						{
							System.IO.File.Delete(oldImgPath);
						}
					}

					websiteInfo.Logo = null;
				}

				// Khi chọn ảnh vào input file
				if (websiteInfo.LogoUpload != null)
				{
					string logo = "logo" + Path.GetExtension(websiteInfo.LogoUpload.FileName);
					// Tạo đường dẫn .../wwwroot/img/[logo.phần_mở_rộng]
					string imgPath = Path.Combine(imgDir, logo);

					using (FileStream fs = new FileStream(imgPath, FileMode.Create))
					{
						websiteInfo.LogoUpload.CopyTo(fs);
					}

					websiteInfo.Logo = logo;
				}

				_context.Update(websiteInfo);
				_context.SaveChanges();

				return Json(new
				{
					success = true,
					title = "Cập nhật thông tin website thành công"
				});
				//return RedirectToAction(nameof(Index));
			}

			return View(nameof(Index), websiteInfo);

			//return Json(new { success = true, title = websiteInfo.LogoUpload?.ToString() ?? "Logo is null" });
		}
	}
}
