using Microsoft.EntityFrameworkCore;
using OmegaStore.Models;

namespace OmegaStore.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreDbContext _context;

        public ProductService (StoreDbContext context)
        {
            _context = context;
        }
        public DbSet<Product> GetProducts() 
        {
            return _context.Products; 
        }

        public async Task<Product> GetProduct(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            return product!;
        }
    }
 }
