using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;
using OmegaStore.Services;

namespace OmegaStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private ICartService _cartService;
        public CartSummaryViewComponent (ICartService cartService)
        {
            _cartService = cartService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.TotalQuantity = _cartService.GetTotalQuantity();
            ViewBag.TotalPrice = _cartService.GetTotalPrice();
            return View();
        }
    }
}
