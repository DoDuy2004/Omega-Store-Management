using OmegaStore.Models;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public Order Order { get; set; } = null!;
        public List<CartItem>? CartItems { get; set; } = null!;
        public double ShipFee { get; set; }
        public double TotalPrice { get; set; }
        public string OrderInfo { get; set; } = string.Empty;
    }
}
