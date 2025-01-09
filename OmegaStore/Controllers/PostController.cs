using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;
using OmegaStore.Services;

namespace OmegaStore.Controllers
{
    public class PostController : Controller
    {
        private readonly StoreDbContext _context;

        public PostController(StoreDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(int pageSize = 6)
        {
            var blogs = _context.Blogs
                .Skip(0)
                .Take(pageSize);

            ViewBag.recentBlogs = _context.Blogs
                .OrderByDescending(b => b.CreatedAt)
                .Take(5).ToList();

            return View(blogs);
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
