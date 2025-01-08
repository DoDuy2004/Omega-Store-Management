using OmegaStore.Models;

namespace OmegaStore.Services
{
    public interface ICartService
    {
        Cart GetCartItems();
        void AddToCart(Product product, int quantity);
        void RemoveFromCart(Product product);
        void ClearCart();
        int GetTotalQuantity();
        decimal GetTotalPrice();
    }
}
