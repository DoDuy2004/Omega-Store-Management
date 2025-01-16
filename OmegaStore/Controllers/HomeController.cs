using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using OmegaStore.Models;
using OmegaStore.Models.ViewModels;
using OmegaStore.Services;
using System.Diagnostics;

namespace OmegaStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly StoreDbContext _context;
        public HomeController(ILogger<HomeController> logger, IProductService productService, StoreDbContext context)
        {
            _logger = logger;
            _productService = productService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var startDate = DateTime.Now.AddDays(-30); 
            // Kiểm tra username trong session
            var username = HttpContext.Session.GetString("Username");

            // Nếu session không tồn tại nhưng cookie "RememberMe" có giá trị
            if (string.IsNullOrEmpty(username) && Request.Cookies["RememberMe"] != null)
            {
                username = Request.Cookies["RememberMe"];
                HttpContext.Session.SetString("Username", username);
            }
            var products = _context.Products.Include(p => p.Reviews);

            var homeViewModel = new HomeViewModel
            {
                BestSellingProducts = await _productService.GetProducts()
                    .Include(p => p.Reviews)
                    .Include(p => p.DetailOrders)
                    .Where(p => p.DetailOrders.Any(d => d.Order!.CreatedAt >= startDate))
                    .OrderByDescending(p => p.DetailOrders
                        .Where(d => d.Order!.CreatedAt >= startDate)
                        .Sum(d => d.Quantity))
                    .Take(15).ToListAsync(),
                NewProducts = await _productService.GetProducts()
                    .Include(p => p.Reviews)
                    .Where(p => p.CreatedAt >= startDate )
					.OrderByDescending(p => p.CreatedAt)
					.Take(15).ToListAsync(),
                HarryPotterProducts = _productService.GetProducts()
                    .Include(p => p.Reviews)
                    .Where(p => p.CategoryId == 3)
					.OrderByDescending(p => p.CreatedAt)
					.Take(15).ToList(),
                DinosaurProducts = _productService.GetProducts()
                    .Include(p => p.Reviews)
                    .Where(p => p.CategoryId == 6)
					.OrderByDescending(p => p.CreatedAt)
					.Take(15).ToList()
			};

            ViewBag.categories = _context.Categories.ToList();

            return View(homeViewModel);
        }
        public IActionResult Contact()
        {
            ViewBag.WebsiteInfo = _context.WebsiteInfos.First(w => w.Id == 1);
            return View();
        }
        [HttpPost]
        public IActionResult CreateRequest(Contact request)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(request);
                _context.SaveChanges();
                return Json(new { success = true, message = "Gửi yêu cầu thành công!" });
            }
            return Json(new { success = false, message = "Dữ liệu không hợp lệ, vui lòng kiểm tra lại." });
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
