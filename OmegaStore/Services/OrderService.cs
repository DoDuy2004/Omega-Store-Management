using OmegaStore.Models;

namespace OmegaStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly StoreDbContext _context;

        public OrderService(StoreDbContext context)
        {
            _context = context;
        }
        public string GenerateOrderCode()
        {
            string currentDate = DateTime.Now.ToString("yyyyMMdd");
            var maxOrderId = _context.Orders.Max(o => (int?)o.Id);
            return $"ORD{currentDate}{maxOrderId+1}";
        }
    }
}
