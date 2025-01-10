namespace OmegaStore.Models.ViewModels
{
    public class ProductOrderViewModel
    {
        public OrderDetail OrderDetail { get; set; }
        public List<ProductDetailViewModel> ProductDetails { get; set; }
    }
}
