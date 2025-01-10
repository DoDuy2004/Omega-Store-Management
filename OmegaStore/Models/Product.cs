using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Product
{
    public int Id { get; set; }
    public string ProductCode { get; set; } = null!;

    [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
    [StringLength(255, ErrorMessage = "Tên sản phẩm không được vượt quá 255 ký tự.")]
    public string Name { get; set; } = null!;
    public string Thumbnail { get; set; } = null!;

    [Required(ErrorMessage = "Tỷ lệ giảm giá phải nằm trong khoảng từ 0 đến 100."), Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0.")]
    public decimal Price { get; set; }

    
    [Required(ErrorMessage = "Tỷ lệ giảm giá phải nằm trong khoảng từ 0 đến 100."), Range(0, 100, ErrorMessage = "Tỷ lệ giảm giá phải nằm trong khoảng từ 0 đến 100.")]
    public int DiscountRate { get; set; }

    public string Slug { get; set; } = null!;

    [Required,Range(0,int.MaxValue,ErrorMessage = "Số lượng tồn kho là bắt buộc.")]
    public int Stock { get; set; }
    public string? Description { get; set; }

    [Required,Range(1,int.MaxValue,ErrorMessage = "Danh mục là bắt buộc.")]
    public int CategoryId { get; set; }
    public int Status { get; set; }

    public virtual Category Category { get; set; } = null!;
    public virtual ICollection<DetailOrder> DetailOrders { get; set; } = new List<DetailOrder>();
    public virtual ICollection<ProductsImage> ProductsImages { get; set; } = new List<ProductsImage>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}

