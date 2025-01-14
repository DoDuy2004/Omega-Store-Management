using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OmegaStore.Models;
using OmegaStore.Models.ViewModels;
using OmegaStore.Services;

namespace OmegaStore.Controllers
{
    public class CartController : Controller
    {
		private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IAccountService _accountService;
        private readonly IOrderService _orderService;
        private readonly int pageSize = 4;
        public CartController (IProductService productService, ICartService cartService, IAccountService accountService, IOrderService orderService)
        {
            _cartService = cartService;
            _productService = productService;
            _accountService = accountService;
            _orderService = orderService;
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

        [HttpGet]
        public IActionResult Checkout()
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
                TotalPrice = totalPrice
            };
            return View(checkout);
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel checkout, string? username)
        {
            int? accountId = null;
            var cartItems = _cartService.GetCart().CartItems;

            ModelState.Remove("Order.OrderCode");

            if(!String.IsNullOrEmpty(username))
            {
                accountId = _accountService.GetAccountId(username!);
            }


            if (!ModelState.IsValid)
            {
                Console.WriteLine("Loi roi duy oi!, thang dan nay...");

                return BadRequest(new { success = false, modelState = ModelState });
            }

            Console.WriteLine("Kha lam!, thang dan nay...");

            Order order = new Order
            {
                OrderCode = _orderService.GenerateOrderCode(),
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

            _cartService.Checkout(order, cartItems);

            _cartService.ClearCart();

            return Json(new { success = true, order = order });
        }
    }
}
