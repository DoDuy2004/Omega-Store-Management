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
        public Cart GetCart()
        {
            var cartSession = _contextAccessor.HttpContext!.Session.GetString(cartSessionKey);

            return string.IsNullOrEmpty(cartSession)
                ? new Cart()
                : JsonConvert.DeserializeObject<Cart>(cartSession) ?? new Cart();
        }
        public bool AddToCart(Product product, int quantity)
        {
            Cart cart = GetCart();
            CartItem cartItem = cart.CartItems.FirstOrDefault(p => p.Product.Id == product.Id)!;

            if (cartItem == null) 
            {
                cartItem = new CartItem
                {
                    CartItemId = cart.CartItems.Count() + 1,
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
            Cart cart = GetCart();
            cart.CartItems.Remove(cart.CartItems.FirstOrDefault(p => p.Product.Id == product.Id)!);

            SaveCartToSession(cart);
        }

        public bool ClearCart()
        {
            Cart cart = GetCart();

            if(cart.CartItems.Count() == 0) {
                return false;
            }
            
            cart.CartItems.Clear();
            SaveCartToSession(cart);
            return true;
        }

        public int GetTotalQuantity()
        {
            Cart cart = GetCart();
            return cart.CartItems.Sum(p => p.Quantity);
        }

        public int GetTotalItems()
        {
            Cart cart = GetCart();
            return cart.CartItems.Count();
        }
        public decimal GetTotalPrice()
        {
            Cart cart = GetCart();
            return cart.CartItems.Sum(p => p.Quantity * (p.Product.Price - (p.Product.Price * p.Product.DiscountRate / 100)));
        }

        public bool IncreaseQuantity(int cartItemId)
        {
            Cart cart = GetCart();
            CartItem cartItem = cart.CartItems.FirstOrDefault(item => item.CartItemId == cartItemId) ?? new CartItem();

            if (cartItem.Quantity >= cartItem.Product.Stock)
            {
                return false;
            }
            cartItem.Quantity++;
            SaveCartToSession(cart);
            return true;
        }

        public bool DecreaseQuantity(int cartItemId)
        {
            Cart cart = GetCart();
            CartItem cartItem = cart.CartItems.FirstOrDefault(item => item.CartItemId == cartItemId) ?? new CartItem();

            if (cartItem.Quantity <= 1)
            {
                return false;
            }
            cartItem.Quantity--;
            SaveCartToSession(cart);
            return true;
        }

        public bool UpdateQuantity(int cartItemId, int quantity)
        {
            Cart cart = GetCart();
            CartItem cartItem = cart.CartItems.FirstOrDefault(item => item.CartItemId == cartItemId) ?? new CartItem();

            if (cartItem.Quantity > cartItem.Product.Stock)
            {
                return false;
            }
            cartItem.Quantity = quantity;
            SaveCartToSession(cart);
            return true;
        }
    }
}
