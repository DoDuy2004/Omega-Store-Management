using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models
{
    public class Wishlist
    {
        [Key]
        public int ProductId { get; set; }

        [Key]
        public int AccountId { get; set; }


        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; } = null!;
    }
}
