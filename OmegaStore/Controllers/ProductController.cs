using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmegaStore.Models;
using OmegaStore.Services;
using X.PagedList;

namespace OmegaStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly StoreDbContext _context;
        private readonly IAccountService _accountService;

        public ProductController(StoreDbContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        [HttpGet("[controller]/{slug}")]
        public IActionResult Detail(string slug)
        {
            var products = _context.Products;
            var product = products
                .Include(p => p.ProductsImages)
                .Include(p => p.Reviews)
                .FirstOrDefault(p => p.Slug == slug);

            ViewBag.product = product;

            if (product != null)
            {
                ViewBag.relatedProducts = products
                    .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id).ToList();

                ViewBag.saleCount = _context.Orders
                    .Join(_context.DetailOrders,
                          o => o.Id,
                          d => d.OrderId,
                          (o, d) => new { d.Quantity, d.ProductId, o.Status })
                    .Where(od => od.Status == 4 && od.ProductId == product.Id)
                    .Sum(od => od.Quantity);

                ViewBag.likes = _context.Wishlist
                    .Where(l => l.ProductId == product.Id).Count();

                var account = _context.Accounts
                    .FirstOrDefault(a => a.Username == HttpContext.Session.GetString("Username"));

                if (account != null)
                {
                    ViewBag.isAddedWishlist = _context.Wishlist
                    .FirstOrDefault(w => w.ProductId == product.Id && w.AccountId == account.Id);
                }
            }

			return View();
        }

        [HttpPost("[controller]/Comment")]
        public JsonResult Comment(Review review, int Rating)
        {
            var reviews = _context.Reviews;
            var orders = _context.Orders;
            var detailOrders = _context.DetailOrders;
            var product = _context.Products.First(p => p.Id == review.ProductId);

            if (ModelState.IsValid)
            {
                var result = orders.Join(detailOrders, o => o.Id, d => d.OrderId,
                    (o, d) => new
                    {
                        Email = o.Email,
                        ProductId = d.ProductId,
                        Status = o.Status
                    });

                var isPurchased = result
                    .FirstOrDefault(o => o.Email == review.Email 
                    && o.ProductId == review.ProductId
                    && o.Status == 4);

                if (isPurchased == null)
                    return Json(new
                    {
                        success = false,
                        title = "Ôii..!",
                        text = "Bạn chưa thực hiện mua sản phẩm này >.<"
                    });

                var isCommented = reviews
                    .FirstOrDefault(r => r.Email == review.Email && r.ProductId == review.ProductId);

                if (isCommented != null)
                    return Json(new
                    {
                        success = false,
                        title = "Ohh...",
                        text = "Bạn đã đánh giá sản phẩm này rồi ^_^"
                    });

                review.Rating = Rating;
                review.Comment = review.Comment ?? "";
                reviews.Add(review);

                _context.SaveChanges();

                return Json(new { success = true, text = "Đánh giá đã được gửi thành công!!" });
            }

            return Json(new
            {
                success = false,
                title = "Hmmm...",
                text = "Vui lòng kiểm tra lại biểu mẫu đánh giá ~~"
            });
        }

        [HttpGet("[controller]/LoadReviews/{ProductId}")]
        public JsonResult LoadReviews(int ProductId)
        {
            var reviews = _context.Reviews.Where(r => r.ProductId == ProductId);
            return Json(new { reviews = reviews });
        }

        [HttpGet]
        [Route("[controller]/[action]/{keyword?}")]
        public IActionResult Search([FromQuery] string keyword, int? page)
        {
            if (keyword == null) keyword = " ";
            var products = _context.Products.Join(_context.Categories, p => p.CategoryId, c => c.Id, (p, c) => new
            { Product = p, Category = c }).Where(pc => pc.Category.Status == 1 && (pc.Product.Name.ToLower().Contains(keyword.ToLower()) || pc.Category.Name.ToLower().Contains(keyword.ToLower()) || pc.Product.Description.Contains(keyword))).ToList();
            ViewBag.Categories = _context.Categories.Where(c => c.Status == 1);
            ViewBag.Keyword = keyword;

            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lst = new PagedList<dynamic>(products, pageNumber, pageSize);
            return View(lst);
        }
        [HttpPost]
        public IActionResult Search(string keyword, int category, int min_price, int max_price, int? page)
        {
            if (keyword == null) keyword = " ";
            var products = _context.Products.Join(_context.Categories, p => p.CategoryId, c => c.Id, (p, c) => new
            { Product = p, Category = c }).Where(pc => pc.Category.Status == 1 && (pc.Product.Name.ToLower().Contains(keyword.ToLower()) || pc.Category.Name.ToLower().Contains(keyword.ToLower()) || pc.Product.Description.Contains(keyword)) && pc.Product.Price >= min_price).ToList();

            if (category != 0)
            {
                if (max_price != 0)
                {
                    products = _context.Products.Join(_context.Categories, p => p.CategoryId, c => c.Id, (p, c)
                    => new { Product = p, Category = c })
                    .Where(pc => pc.Category.Status == 1
                    && (pc.Product.Name.ToLower().Contains(keyword.ToLower())
                    || pc.Category.Name.ToLower().Contains(keyword.ToLower()) 
                    || pc.Product.Description.Contains(keyword))
                    && pc.Category.Id == category
                    && pc.Product.Price >= min_price
                    && pc.Product.Price <= max_price
                    ).ToList();
                }
                else
                {
                    products = _context.Products.Join(_context.Categories, p => p.CategoryId, c => c.Id, (p, c)
                        => new { Product = p, Category = c })
                        .Where(pc => pc.Category.Status == 1
                        && (pc.Product.Name.ToLower().Contains(keyword.ToLower())
                        || pc.Category.Name.ToLower().Contains(keyword.ToLower()) 
                        || pc.Product.Description.Contains(keyword))
                        && pc.Category.Id == category
                        && pc.Product.Price >= min_price
                        ).ToList();
                }
            }

            ViewBag.Categories = _context.Categories.Where(c => c.Status == 1);
            ViewBag.Keyword = keyword;

            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lst = new PagedList<dynamic>(products, pageNumber, pageSize);
            return View("Search", lst);
        }
    }
}
