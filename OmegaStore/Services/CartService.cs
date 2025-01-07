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

        public void AddToCart(Product product, int quantity)
        {
            Cart cart = GetCartItems();
            CartItem cartItem = cart.CartItems.FirstOrDefault(p => p.Product.Id == product.Id)!;

            if (cartItem == null) 
            {
                cart.CartItems.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            SaveCartToSession(cart);
        }

        public void RemoveFromCart(Product product)
        {
            Cart cart = GetCartItems();
            cart.CartItems.Remove(cart.CartItems.FirstOrDefault(p => p.Product.Id == product.Id)!);

            SaveCartToSession(cart);
        }

        public void ClearCart()
        {
            Cart cart = GetCartItems();
            cart.CartItems.Clear();
            SaveCartToSession(cart);
        }

        public int GetTotalQuantity()
        {
            Cart cart = GetCartItems();
            return cart.CartItems.Sum(p => p.Quantity);
        }
            

        public decimal GetTotalPrice()
        {
            Cart cart = GetCartItems();
            return cart.CartItems.Sum(p => p.Quantity * p.Product.Price);
        }
    }
}
