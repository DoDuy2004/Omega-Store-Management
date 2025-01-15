using OmegaStore.Models;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public Order Order { get; set; } = null!;
        public List<CartItem>? CartItems { get; set; } = null!;
        public decimal? ShipFee { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
