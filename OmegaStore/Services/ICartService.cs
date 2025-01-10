using OmegaStore.Models;

namespace OmegaStore.Services
{
    public interface ICartService
    {
        Cart GetCart();
        bool AddToCart(Product product, int quantity);
        void RemoveFromCart(Product product);
        bool ClearCart();
        int GetTotalQuantity();
        int GetTotalItems();
        decimal GetTotalPrice();

        bool IncreaseQuantity(int cartItemId);
        bool UpdateQuantity(int cartItemId, int quantity);
        bool DecreaseQuantity(int cartItemId);
    }
}
