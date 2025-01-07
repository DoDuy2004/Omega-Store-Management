using Microsoft.AspNetCore.Mvc;
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
            var cart = _cartService.GetCartItems();
            return View(cart.CartItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var product = await _productService.GetProduct(productId);

            _cartService.AddToCart(product, 1);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveItem(int productId)
        {
            var product = await _productService.GetProduct(productId);

            _cartService.RemoveFromCart(product);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ClearCart()
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
