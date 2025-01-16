namespace OmegaStore.Models.ViewModels
{
    public class OrderDetailCustomerAllViewModel
    {
        public OrderDetailCustomerViewModel OrderDetailCustomerViewModel { get; set; }
        public List<OrderDetailProductListCustomerViewModel> OrderDetailProductListCustomerViewModels { get; set; }

    }
}
