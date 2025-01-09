using Newtonsoft.Json;
using OmegaStore.Models;

namespace OmegaStore.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string cartSessionKey = "Cart";

        public CartService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        private void SaveCartToSession(Cart cart)
        {
            _contextAccessor.HttpContext!.Session.SetString(cartSessionKey, JsonConvert.SerializeObject(cart));
        }
        public Cart GetCartItems()
        {
            var cartSession = _contextAccessor.HttpContext!.Session.GetString(cartSessionKey);

            return string.IsNullOrEmpty(cartSession)
                ? new Cart()
                : JsonConvert.DeserializeObject<Cart>(cartSession) ?? new Cart();
        }

        public bool AddToCart(Product product, int quantity)
        {
            Cart cart = GetCartItems();
            CartItem cartItem = cart.CartItems.FirstOrDefault(p => p.Product.Id == product.Id)!;

            if (cartItem == null) 
            {
                cartItem = new CartItem
                {
                    Product = product,
                    Quantity = quantity
                };
                cart.CartItems.Add(cartItem);    
            }
            else
            {
                cartItem.Quantity += quantity;

                if(cartItem.Quantity > product.Stock) {
                    return false;
                }
            }
            SaveCartToSession(cart);

            return true;
        }

        public void RemoveFromCart(Product product)
        {
            Cart cart = GetCartItems();
            cart.CartItems.Remove(cart.CartItems.FirstOrDefault(p => p.Product.Id == product.Id)!);

            SaveCartToSession(cart);
        }

        public bool ClearCart()
        {
            Cart cart = GetCartItems();

            if(cart.CartItems.Count() == 0) {
                return false;
            }
            
            cart.CartItems.Clear();
            SaveCartToSession(cart);
            return true;
        }

        public int GetTotalQuantity()
        {
            Cart cart = GetCartItems();
            return cart.CartItems.Count();
        }
            

        public decimal GetTotalPrice()
        {
            Cart cart = GetCartItems();
            return cart.CartItems.Sum(p => p.Quantity * (p.Product.Price - (p.Product.Price * p.Product.DiscountRate / 100)));
        }
    }
}
