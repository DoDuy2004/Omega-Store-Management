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
        public async Task<ICollection<Product>> GetProducts() 
        {
            return await _context.Products.ToListAsync(); 
        }

        public async Task<Product> GetProduct(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            return product!;
        }
    }
 }
