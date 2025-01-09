using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Product
{
    public int Id { get; set; }
    public string ProductCode { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Thumbnail { get; set; } = null!;
    public decimal Price { get; set; }
    public int DiscountRate { get; set; }
    public string Slug { get; set; } = null!;
    public int Stock { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public int Status { get; set; }

    public virtual Category Category { get; set; } = null!;
    public virtual ICollection<DetailOrder> DetailOrders { get; set; } = new List<DetailOrder>();
    public virtual ICollection<ProductsImage> ProductsImages { get; set; } = new List<ProductsImage>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}

