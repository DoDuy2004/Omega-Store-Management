namespace OmegaStore.Models.ViewModels
{
    public class OrderDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Img { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public decimal Total { get; set; }

        public string Address { get; set; }
        public bool PaymentMethod { get; set; }
        
    }
}
