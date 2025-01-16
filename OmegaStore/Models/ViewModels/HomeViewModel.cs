namespace OmegaStore.Models.ViewModels
{
	public class HomeViewModel
	{
		public List<Product> BestSellingProducts { get; set; } = null!;
		public List<Product> NewProducts { get; set; } = null!;
		public List<Product> HarryPotterProducts { get; set; } = null!;
		public List<Product> DinosaurProducts { get; set; } = null!;
	}
}
