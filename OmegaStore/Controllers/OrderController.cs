using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmegaStore.Models;
using OmegaStore.Models.ViewModels;
using OmegaStore.Services;

namespace OmegaStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly StoreDbContext _context;

        public OrderController(IAccountService accountService, StoreDbContext context)
        {
         
            _context = context;
        }
        public IActionResult Index(int id)
        {
            //var CheckOrderDetail = _context.Orders
            //      .Where(o => o.Id == id)
            //    .Include(o => o.DetailOrders)
            //    .ThenInclude(p => p.Product).ToList();
          


            // Thông tin chi tiết đơn hàng
                var OrderDetail = _context.Orders
                  .Where(o => o.Id == id)
                .Include(o => o.DetailOrders)
                .ThenInclude(p => p.Product).Select(p => new OrderDetailCustomerViewModel
                {
                    OrderCodeId = p.OrderCode,
                    Note=p.Note,
                    Crreate_at = p.CreatedAt,
                    StatusOrder = p.Status,
                    Name = p.Fullname,
                    PhoneNumber = p.Phone,
                    EmailUser = p.Email,
                    AddressUser = p.Address,
                    Total=p.TotalAmount,
                }).FirstOrDefault();

          
           

            //var CheckProductListOrderDetail = _context.DetailOrders
            //                     .Where(d => d.OrderId == id)
            //                    .Include(d => d.Product).ToList();


           // Thông tin chi tiết danh sách sản phẩm đơn hàng
                var ProductListOrderDetail = _context.DetailOrders
                                 .Where(d => d.OrderId == id)
                                .Include(d => d.Product).Select(p => new OrderDetailProductListCustomerViewModel
                                {
                                    ProductSlug=p.Product.Slug,
                                    Thumbnail = p.Product.Thumbnail,
                                    Name = p.Product.Name,
                                    Price = p.Product.Price,
                                    DiscountRate = p.Product.DiscountRate,
                                    Quantity = p.Quantity,
                                    TotalPrice = p.TotalPrice,

                                }).ToList();

        

            var ViewModelDetailOrder = new OrderDetailCustomerAllViewModel()
            {
                OrderDetailCustomerViewModel = OrderDetail,
                OrderDetailProductListCustomerViewModels = ProductListOrderDetail.Any() ? ProductListOrderDetail : null

			};
            return View(ViewModelDetailOrder);
        }
    }
}
