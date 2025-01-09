using OmegaStore.Models;

namespace OmegaStore.Services
{
    public interface ICartService
    {
        Cart GetCartItems();
        bool AddToCart(Product product, int quantity);
        void RemoveFromCart(Product product);
        bool ClearCart();
        int GetTotalQuantity();
        decimal GetTotalPrice();
    }
}
