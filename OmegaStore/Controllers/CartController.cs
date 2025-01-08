using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models.ViewModels;
using OmegaStore.Services;

namespace OmegaStore.Controllers
{
    public class CartController : Controller
    {
		private readonly IProductService _productService;
        private readonly ICartService _cartService;
        public CartController (IProductService productService, ICartService cartService)
        {
            _cartService = cartService;
            _productService = productService;
        }
		public IActionResult Index()
        {
            var cartVM = new CartViewModel
            { 
                CartItems = _cartService.GetCartItems().CartItems,
                TotalPrice = _cartService.GetTotalPrice(),
                ShippingFee = 25000
			};

            return View(cartVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var product = await _productService.GetProduct(productId);

            _cartService.AddToCart(product, quantity);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> RemoveItem(int productId)
        {
            var product = await _productService.GetProduct(productId);

            _cartService.RemoveFromCart(product);

            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            _cartService.ClearCart();

            return RedirectToAction("Index");
        }

        public IActionResult Checkout() 
        { 
            return View(); 
        }
    }
}
