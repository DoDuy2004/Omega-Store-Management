using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string ProductCode { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string Thumbnail { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public decimal? DiscountRate { get; set; }

    [Required]
    [StringLength(255)]
    public string Slug { get; set; } = null!;

    [Required]
    public int Stock { get; set; }

    public string? Description { get; set; }

    [Required]
    [Display(Name = "Category")]
    public int CategoryId { get; set; }

    [Required]
    public int Status { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<DetailOrder> DetailOrders { get; set; } = new List<DetailOrder>();

    public virtual ICollection<ProductsImage> ProductsImages { get; set; } = new List<ProductsImage>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
