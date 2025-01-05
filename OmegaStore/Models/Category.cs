using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string? Description { get; set; }

    [Required]
    [StringLength(100)]
    public string Slug { get; set; } = null!;

    [Required]
    public int Status { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
