namespace OmegaStore.Models.ViewModels
{
    public class OrderDetailCustomerViewModel
    {
        public int Id { get; set; }
        public string OrderCodeId { get; set; }
        public string Name { get; set; }

        public string ? Note {  get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? EmailUser { get; set; }

        public DateTime? Crreate_at { get; set; } = DateTime.Now;

        public decimal Total { get; set; }

        public string AddressUser { get; set; }
        public int StatusOrder { get; set; }
    }
}
