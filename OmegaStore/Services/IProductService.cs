using OmegaStore.Models;

namespace OmegaStore.Services
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetProducts();
        Task<Product> GetProduct(int productId);
    }
}
