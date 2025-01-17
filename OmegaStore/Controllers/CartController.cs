using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OmegaStore.Models;
using OmegaStore.Models.ViewModels;
using OmegaStore.Services;
using OmegaStore.Services.Momo;

namespace OmegaStore.Controllers
{
    public class CartController : Controller
    {
		private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IAccountService _accountService;
        private readonly IOrderService _orderService;
        private readonly IMomoService _momoService;
        private readonly int pageSize = 4;
        public CartController (IProductService productService, ICartService cartService,
            IAccountService accountService, IOrderService orderService, IMomoService momoService)
        {
            _cartService = cartService;
            _productService = productService;
            _accountService = accountService;
            _orderService = orderService;
            _momoService = momoService;
        }
		public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetCart(int currentPage = 1)
        {
            var cartViewModel = new CartViewModel
            {
                CartItems = _cartService.GetCart().CartItems
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),
                TotalPrice = _cartService.GetTotalPrice(),
                TotalQuantity = _cartService.GetTotalQuantity(),
                TotalItems = _cartService.GetTotalItems()
            };

            return Json(cartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var product = await _productService.GetProduct(productId);

            bool isAddToCart = _cartService.AddToCart(product, quantity);

            if (!isAddToCart)
            {
                return Json(new { success = false });
            }
            var cartViewModel = new CartViewModel
            {
                CartItems = _cartService.GetCart().CartItems,
                TotalPrice = _cartService.GetTotalPrice(),
                TotalQuantity = _cartService.GetTotalQuantity(),
                TotalItems = _cartService.GetTotalItems()
            };

            return Json(new { success = true, cartViewModel = cartViewModel });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItem(int productId)
        {
            var product = await _productService.GetProduct(productId);
            
            if(product != null)
            {
                _cartService.RemoveFromCart(product);

                return Json(new { success = true, newTotalPrice = _cartService.GetTotalPrice() });
            }

            return Json(new { success = false, message = "Sản phẩm không tồn tại trong giỏ hàng." });
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            bool isClearCart = _cartService.ClearCart();

            if(!isClearCart) {
                return Json(new { success = false });
            }
            return Json(new { success = true });
        }

        public IActionResult IncreaseQuantity(int cartItemId)
        {
            if(!_cartService.IncreaseQuantity(cartItemId))
            {
                return Json(new { success = false });
            }

            var cartViewModel = new CartViewModel
            {
                CartItems = _cartService.GetCart().CartItems,
                TotalPrice = _cartService.GetTotalPrice(),
                TotalQuantity = _cartService.GetTotalQuantity(),
                TotalItems = _cartService.GetTotalItems()
            };
            return Json(new { success = true, cartViewModel = cartViewModel });
        }
        public IActionResult DecreaseQuantity(int cartItemId)
        {
            if(!_cartService.DecreaseQuantity(cartItemId))
            {
                return Json(new { success = false });
            }
            var cartViewModel = new CartViewModel
            {
                CartItems = _cartService.GetCart().CartItems,
                TotalPrice = _cartService.GetTotalPrice(),
                TotalQuantity = _cartService.GetTotalQuantity(),
                TotalItems = _cartService.GetTotalItems()
            };
            return Json(new { success = true, cartViewModel = cartViewModel });
        }
        public IActionResult UpdateQuantity(int cartItemId, int quantity)
        {
            if(!_cartService.UpdateQuantity(cartItemId, quantity))
            {
                return Json(new { success = false });
            }
            var cartViewModel = new CartViewModel
            {
                CartItems = _cartService.GetCart().CartItems,
                TotalPrice = _cartService.GetTotalPrice(),
                TotalQuantity = _cartService.GetTotalQuantity(),
                TotalItems = _cartService.GetTotalItems()
            };
            return Json(new { success = true, cartViewModel = cartViewModel });
        }

        [HttpPost]
        public IActionResult FormCheckout()
        {
            var cartItems = _cartService.GetCart().CartItems;
            var totalPrice = _cartService.GetTotalPrice();

            Account? account = new Account();
            var username = HttpContext.Session.GetString("Username");

            if (!String.IsNullOrEmpty(username))
            {
                account = _accountService.GetAccountByUsername(username);
            }

            var checkout = new CheckoutViewModel
            {
                Order = new Order
                {
                    Fullname = account!.Fullname,
                    Email = account!.Email,
                    Phone = account!.Phone,
                    Address = account!.Address
                },
                CartItems = cartItems,
                ShipFee = 25000,
                TotalPrice = (double)totalPrice
            };
            return View("Checkout", checkout);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel checkout, string? username)
        {
            checkout.Order.OrderCode = _orderService.GenerateOrderCode();

            // Momo
            if (checkout.Order.PaymentMethod)
            {
                int? accountId = null;
                var cartItems = _cartService.GetCart().CartItems;

                if (!String.IsNullOrEmpty(username))
                {
                    accountId = _accountService.GetAccountId(username!);
                }

                checkout.CartItems = cartItems;
                checkout.Order.AccountId = accountId;
                checkout.Order.Status = 1;

                // Lưu session về đơn hàng thanh toán
                _cartService.SetCheckoutOrder(checkout);

                // Tạo request đến MomoAPI
                var response = await _momoService.CreatePaymentMomo(checkout);
                return Redirect(response.PayUrl);
            }
            // COD
            else
            {
                int? accountId = null;
                var cartItems = _cartService.GetCart().CartItems;

                ModelState.Remove("Order.OrderCode");

                // Lấy id account khi đã đăng nhập
                if (!String.IsNullOrEmpty(username))
                {
                    accountId = _accountService.GetAccountId(username!);
                }

                if (!ModelState.IsValid)
                {
                    return View("FailedCheckout");
                }

                Order order = new Order
                {
                    OrderCode = checkout.Order.OrderCode,
                    Fullname = checkout.Order.Fullname,
                    Email = checkout.Order.Email,
                    Phone = checkout.Order.Phone,
                    PaymentMethod = checkout.Order.PaymentMethod,
                    Address = checkout.Order.Address,
                    TotalAmount = checkout.Order.TotalAmount,
                    Note = checkout.Order.Note,
                    AccountId = accountId,
                    Status = 1,
                };
                // Tạo đơn hàng
                _cartService.Checkout(order, cartItems);
                // Xóa session giỏ hàng
                _cartService.ClearCart();

                return View("SuccessfulCheckout", order);
            }
        }

        [HttpGet]
        public IActionResult PaymentCallBack()
        {
            var response = _momoService.PaymentExcuteAsync(HttpContext.Request.Query);
            var requestQuery = HttpContext.Request.Query;

            // Giao dịch với Momo thành công
            if (requestQuery["message"] == "Success")
            {
                // Lấy thông tin đơn hàng thanh toán
                CheckoutViewModel checkout = _cartService.GetCheckoutOrder();

                Order order = new Order
                {
                    OrderCode = checkout.Order.OrderCode,
                    Fullname = checkout.Order.Fullname,
                    Email = checkout.Order.Email,
                    Phone = checkout.Order.Phone,
                    PaymentMethod = checkout.Order.PaymentMethod,
                    Address = checkout.Order.Address,
                    TotalAmount = checkout.Order.TotalAmount,
                    Note = checkout.Order.Note,
                    AccountId = checkout.Order.AccountId,
                    Status = checkout.Order.Status,
                };

                // Tạo đơn hàng
                _cartService.Checkout(order, checkout.CartItems!);
                // Xóa session liên quan
                _cartService.ClearCart();
                _cartService.RemoveCheckoutOrder();

                return View("SuccessfulCheckout", order);
            }
            // Giao dịch với Momo thất bại
            else
            {
                // Xóa session đơn hàng thanh toán
                _cartService.RemoveCheckoutOrder();
                return View("FailedCheckout");
            }
        }
    }
}
