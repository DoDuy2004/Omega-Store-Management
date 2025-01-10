namespace OmegaStore.Models.ViewModels
{
    public class ProductCategoryModel
    {
        public List<Product> Products { get; set; }
        public List<CategoryProductListViewModel> CategoryProducts { get; set; }

        
    }
}
