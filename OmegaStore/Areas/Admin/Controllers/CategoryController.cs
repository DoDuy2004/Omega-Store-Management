using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;
using System.Text.RegularExpressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly StoreDbContext _context;

        public CategoryController(StoreDbContext context)
        {
            _context = context;
        }
        //Trang Danh sách Danh mục
        public async Task<IActionResult> Index()
        {
            var categories = _context.Categories.Where(c => c.Status == 1).ToListAsync(); // Lấy tất cả các danh mục từ cơ sở dữ liệu
            return View(await categories); // Truyền danh sách danh mục vào View
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        [Route("[controller]/[action]/{slug?}")]
        public async Task<IActionResult> Edit(string slug)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Slug == slug);
            return View(category);
        }
        public async Task<IActionResult> Delete(string slug)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Slug == slug);
            if (category != null)
            {
                category.Status = 0;
                _context.SaveChanges();
                TempData["success"] = "Xóa danh mục thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Xóa danh mục không thành công.";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Search(string keyword)
        {
            string value = keyword.ToLower().Trim();
            List<Category> categories = _context.Categories.Where(c => c.Name.ToLower().Contains(value) || c.Slug.Contains(value)).ToList();
            if (categories.Count > 0)
            {
                return View("Index", categories);
            }
            TempData["error"] = "Không tìm thấy kết quả nào.";
            return View("Index", categories);
        }
        public string ToSlug(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            string slug = stringBuilder.ToString().Normalize(NormalizationForm.FormC);
            slug = slug.ToLowerInvariant();
            slug = slug.Replace("đ", "d");
            slug = Regex.Replace(slug, @"\s+", "-");
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "", RegexOptions.IgnoreCase);
            slug = slug.Trim('-');
            return slug;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var slug = ToSlug(category.Name);
                category.Slug = slug;
                category.Status = 1;
                var checkSlug = await _context.Categories.FirstOrDefaultAsync(c => c.Slug == slug);
                if (checkSlug != null)
                {
                    if (checkSlug.Status == 1)
                    {
                        ModelState.AddModelError("", "Danh mục đã tồn tại");
                        return View(category);
                    }
                    else
                    {
                        checkSlug.Status = 1;
                        await _context.SaveChangesAsync();
                        TempData["success"] = "Thêm danh mục thành công";
                        return RedirectToAction("Index");
                    }
                }
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                TempData["success"] = "Thêm danh mục thành công";
                return RedirectToAction("Index");

            }
            else
            {
                //TempData["error"] = "Model Error";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                Category cat = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
                var slugNew = ToSlug(category.Name);
                cat.Name = category.Name;
                cat.Description = category.Description;
                cat.Slug = slugNew;
                if (category.Slug != slugNew)
                {
                    var checkSlug = await _context.Categories.FirstOrDefaultAsync(c => c.Slug == slugNew);
                    if (checkSlug != null)
                    {
                        if (checkSlug.Status == 1)
                        {
                            ModelState.AddModelError("", "Danh mục đã tồn tại");
                            return View("Edit", category);
                        }
                    }
                }
                await _context.SaveChangesAsync();
                TempData["success"] = "Thay đổi danh mục thành công";
                return RedirectToAction("Index");
            }
            else
            {
                //TempData["error"] = "Model Error";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }

        }

    }
}
