using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Category
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Yêu cầu nhập tên danh mục")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Yêu cầu nhập mô tả danh mục")]
    public string? Description { get; set; }
    public string? Slug { get; set; } = null!;
    public int Status { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
