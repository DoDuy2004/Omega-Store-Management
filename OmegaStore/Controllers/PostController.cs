using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;
using OmegaStore.Services;
using System.Web;

namespace OmegaStore.Controllers
{
    public class PostController : Controller
    {
        private readonly StoreDbContext _context;

        public PostController(StoreDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            ViewBag.recentBlogs = _context.Blogs
                .OrderByDescending(b => b.CreatedAt)
                .Take(5).ToList();
            return View();
        }

        public IActionResult List(string searchQuery = "", int page = 1, int pageSize = 4)
        {
            var query = _context.Blogs.ToList();
            var normalQuery = searchQuery;
            // Lọc theo từ khóa tìm kiếm
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = CreateUnaccentedText(searchQuery);
                query = query.Where(b => CreateUnaccentedText(b.Title).Contains(searchQuery) || CreateUnaccentedText( b.ShortContent).Contains(searchQuery)).ToList();
            }

            // Phân trang
            var totalItems = query.Count();
            var blogs = query
                .OrderByDescending(b => b.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.SearchQuery = normalQuery;
            ViewBag.result = totalItems;
            return PartialView("_PostListPartial", blogs);
        }


        [HttpGet("[controller]/[action]/{slug}")]
        public IActionResult Detail(string slug)
        {
            var blog = _context.Blogs.FirstOrDefault(u => u.Slug == slug);
            if (blog == null)
            {
                return NotFound();
            }
            ViewBag.recentBlogs = _context.Blogs
                .OrderByDescending(b => b.CreatedAt)
                .Take(5).ToList();
            return View(blog);
        }

        public static string CreateUnaccentedText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;
            //Hàng đầu tiên là chữ không dấu, các hàng sau là chữ có dấu, sắp xếp đúng theo thứ tự của hàng đầu
            string[] vietnamese = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };

            // Thay thế các ký tự có dấu thành không dấu
            for (int i = 1; i < vietnamese.Length; i++)
            {
                foreach (var c in vietnamese[i])
                {
                    input = input.Replace(c, vietnamese[0][i - 1]);
                }
            }
            //Trả về kết quả,bỏ tất cả khoảng trắng, viết thường.
            return input.Replace(" ","").ToLower();
        }
    }
}
