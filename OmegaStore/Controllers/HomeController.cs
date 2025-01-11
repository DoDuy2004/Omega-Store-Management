using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using OmegaStore.Models;
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
            var products = await _productService.GetProducts();
            return View(products);
        }
        public IActionResult Contact()
        {
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
