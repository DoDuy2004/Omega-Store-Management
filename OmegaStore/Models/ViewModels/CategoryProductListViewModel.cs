namespace OmegaStore.Models.ViewModels
{
    public class CategoryProductListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Slug { get; set; }
        public int DiscountRate { get; set; }
        public string Img { get; set; }
        public float Rating { get; set; }

        public int Views {  get; set; }
    }
}
