using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OmegaStore.Models;
using OmegaStore.Models.ViewModels;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {

        private readonly StoreDbContext _Context;
        public OrderController(ILogger<HomeController> logger, StoreDbContext StoreDbContext)
        {

            _Context = StoreDbContext;
        }
        public async Task<IActionResult>Index(int ? status,string ? search)
        {

            var GetStatus = status;

            var OrderList =status.HasValue ? await _Context.Orders.Where(o=>o.Status==status).ToListAsync() :await _Context.Orders.Where(o=>o.Status!=0).ToListAsync();
            if (!search.IsNullOrEmpty())
            {
                var searchQuery = await _Context.Orders.Where(o => o.Fullname.Contains(search) && o.Status !=0).ToListAsync();
                ViewBag.Order = searchQuery;
                ViewBag.Status = GetStatus;
                ViewBag.Btn = "btn-primary btn-outline";
                return View();
            }
            ViewBag.Order = OrderList;
            ViewBag.Status = GetStatus;
            ViewBag.Btn = "btn-primary btn-outline";
            return View();
        }
        [HttpPost]
        public IActionResult UpdateStatus(int orderid, int status)
        {

            try
            {
             
                var order = _Context.Orders.FirstOrDefault(o => o.Id == orderid);
                if (order == null)
                {
                    return Json(new { success = false});
                }
                int st = status;
                order.Status = status;
                _Context.SaveChanges();
    

                return Json(new { success = true, st = st });
            }
            catch (Exception ex)
            {
                return Json(new { success = false});
            }
        }
        [HttpPost]
        public IActionResult CancelOrder(int orderid, int status)
        {

            try
            {
                var order = _Context.Orders.FirstOrDefault(o => o.Id == orderid);
                if (order == null)
                {
                    return Json(new { success = false });
                }

                order.Status = status;
                _Context.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        public async Task<IActionResult> RemoveOrder(int orderid, int status)
        {

            try
            {
                var order = await _Context.Orders.FirstOrDefaultAsync(o => o.Id == orderid);
          
                if (order == null)
                {
                    return Json(new { success = false});
                }
            
                order.Status = status;
                _Context.Orders.Update(order);
               await _Context.SaveChangesAsync();
          
           
                return Json(new { success = true});
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }
        public IActionResult Detail(int id)
        {

            var productsDetail = _Context.DetailOrders
               .Include(p => p.Product) // Bao gồm thông tin sản phẩm
               .Where(p => p.OrderId == id) // Lọc theo OrderId
               .Select(p => new ProductDetailViewModel
               {
                   Id = p.Product.Id,
                   Name = p.Product.Name,
                   Discount_Rate=p.Product.DiscountRate,
                   Quantity = p.Quantity,
                   Price = p.Product.Price,
                   Img = p.Product.Thumbnail
               })
               .ToList();

            ViewBag.Products = productsDetail;

            var DetailOrder = _Context.DetailOrders
            .Include(p => p.Product) // Lấy hình ảnh liên quan
            .Include(p => p.Order)
            .Where(p => p.OrderId == id).Select(p=>new OrderDetail { 
                Id=p.Order.OrderCode,
                Name=p.Product.Name,
                Img=p.Product.Thumbnail,
                Quantity=p.Quantity,
                Price=p.Product.Price,
                CreatedAt=p.Order.CreatedAt,
                Total=p.Order.TotalAmount,
                Address=p.Order.Address,
                PaymentMethod=p.Order.PaymentMethod,



            }).FirstOrDefault();

            var ModelProductOrder = new ProductOrderViewModel
            {
                OrderDetail = DetailOrder,
                ProductDetails=productsDetail
            };

            return View(ModelProductOrder);
        }
    }
}
