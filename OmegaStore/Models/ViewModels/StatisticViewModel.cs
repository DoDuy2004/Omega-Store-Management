namespace OmegaStore.Models.ViewModels
{
	public class StatisticViewModel
	{
		public int TotalProductSold { get; set; }
		public int TotalOrderCompleted { get; set; }
		public int TotalProduct { get; set; }
		public int TotalCategory { get; set; }
		public List<Order>? NewOrders { get; set; }
		public List<BestSellingProduct>? BestSellingProducts { get; set; }

		public List<Revenue>? Revenues { get; set; }

	}

	public class BestSellingProduct
	{
        public int ProductId { get; set; }
		public string Thumbnail { get; set; } = null!;
		public string ProductName { get; set; } = null!;
		public int Stock { get; set; }
        public int TotalQuantitySold { get; set; }
    }

	public class Revenue
	{
		public int Month { get; set; }
		public decimal TotalRevenue { get; set; }
	}
}
