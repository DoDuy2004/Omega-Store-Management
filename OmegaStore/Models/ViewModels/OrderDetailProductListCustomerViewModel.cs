namespace OmegaStore.Models.ViewModels
{
    public class OrderDetailProductListCustomerViewModel
    {
        public string ProductSlug { get; set; }
        public string Thumbnail { get; set; } = null!;
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
        public int DiscountRate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
