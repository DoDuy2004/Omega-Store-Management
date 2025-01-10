using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;
using OmegaStore.Models.ViewModels;
using OmegaStore.Services;

namespace OmegaStore.Controllers
{
    public class CartController : Controller
    {
		private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly int pageSize = 4;
        public CartController (IProductService productService, ICartService cartService)
        {
            _cartService = cartService;
            _productService = productService;
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
                ShippingFee = 25000,
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
                ShippingFee = 25000,
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
                ShippingFee = 25000,
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
                ShippingFee = 25000,
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
                ShippingFee = 25000,
                TotalQuantity = _cartService.GetTotalQuantity(),
                TotalItems = _cartService.GetTotalItems()
            };
            return Json(new { success = true, cartViewModel = cartViewModel });
        }
        public IActionResult Checkout() 
        { 
            return View(); 
        }
    }
}
