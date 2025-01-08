using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;

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
        public IActionResult Index()
        {
            var Order = _Context.Orders.ToList();
            return View(Order);
        }
        [HttpPost]
        public IActionResult UpdateStatus(int orderid, int status)
        {

            try
            {
             
                var order = _Context.Orders.FirstOrDefault(o => o.Id == orderid);
                if (order == null)
                {
                    return Json(new { success = false, message = "Đơn hàng không tồn tại" });
                }
                int st = status;
                order.Status = status;
                _Context.SaveChanges();
    

                return Json(new { success = true, message = $"Trạng thái đơn hàng {orderid} đã được cập nhật.", st = st });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
            }
        }
        [HttpPost]
        public IActionResult DeleteOrder(int orderid, int status)
        {

            try
            {
                var order = _Context.Orders.FirstOrDefault(o => o.Id == orderid);
                if (order == null)
                {
                    return Json(new { success = false, message = "Hủy đơn hàng không thành công" });
                }

                order.Status = status;
                _Context.SaveChanges();

                return Json(new { success = true, message = $"Đã hủy đơn hàng {orderid}." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
            }
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
