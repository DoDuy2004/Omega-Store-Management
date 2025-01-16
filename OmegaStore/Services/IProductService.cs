using Microsoft.EntityFrameworkCore;
using OmegaStore.Models;

namespace OmegaStore.Services
{
    public interface IProductService
    {
        DbSet<Product> GetProducts();
        Task<Product> GetProduct(int productId);
    }
}
