using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class DetailOrder
{
    [Key]
    [ForeignKey("Order")]
    public int OrderId { get; set; }

    [Key]
    [ForeignKey("Product")]
    public int ProductId { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal TotalPrice { get; set; }

    [ForeignKey(nameof(OrderId))]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;
}
