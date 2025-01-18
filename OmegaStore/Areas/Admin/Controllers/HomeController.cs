using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmegaStore.Models;
using OmegaStore.Models.ViewModels;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly StoreDbContext _context;

        public HomeController(StoreDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var startDate = DateTime.Now.AddDays(-30);

            var username = HttpContext.Session.GetString("AdminUsername");
            if (username == null)
            {
                return RedirectToAction("LoginView", "Account");
            }
            ViewData["AccountName"] = username;

            StatisticViewModel statisticViewModel = new StatisticViewModel
            {
                TotalProductSold = _context.DetailOrders.Where(d => d.Order!.Status == 4).Sum(d => d.Quantity),
                TotalProduct = _context.Products.Where(p => p.Status == 1).Count(),
                TotalOrderCompleted = _context.Orders.Where(o => o.Status == 4).Count(),
                TotalCategory = _context.Categories.Where(o => o.Status == 1).Count(),
                Revenues = _context.Orders
				    .Where(o => o.Status == 4 && o.CreatedAt.HasValue && o.CreatedAt.Value.Year == 2025) // Lọc năm 2025
		            .GroupBy(o => o.CreatedAt.Value.Month) // Nhóm theo tháng
		            .Select(group => new Revenue
		            {
			            Month = group.Key, // Hiển thị tháng và năm
			            TotalRevenue = group.Sum(o => o.TotalAmount) // Tổng doanh thu trong tháng
		            })
		            .OrderBy(r => r.Month)
		            .ToList(),
                NewOrders = _context.Orders.Where(o => o.Status == 1).ToList(),
                BestSellingProducts = _context.DetailOrders
                    .Include(d => d.Product)
                    .Where(d => d.Order!.Status == 4 && d.Order!.CreatedAt >= startDate)
                    .GroupBy(d => new 
                    {
                        d.ProductId,
                        d.Product.Name,
                        d.Product.Stock,
                        d.Product.Thumbnail,
                    })
                    .Select(group => new BestSellingProduct
                    {
                        ProductId = group.Key.ProductId,
                        ProductName = group.Key.Name,
                        Thumbnail = group.Key.Thumbnail,
                        Stock = group.Key.Stock,
                        TotalQuantitySold = group.Sum(d => d.Quantity)
                    })
                    .OrderByDescending(x => x.TotalQuantitySold)
                    .Take(5)
                    .ToList()

            };

            ViewBag.ChartLabels = statisticViewModel.Revenues.Select(r => $"Tháng {r.Month}").ToList();
            ViewBag.ChartData = statisticViewModel.Revenues.Select(r => r.TotalRevenue).ToList();

            return View(statisticViewModel);
        }

        public IActionResult Roles()
        {
            var roles = _context.Roles.ToList(); // Lấy tất cả các danh mục từ cơ sở dữ liệu
            return View(roles); // Truyền danh sách danh mục vào View
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult Component()
        {
            return View();
        }
    }
}
