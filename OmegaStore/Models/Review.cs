using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Review
{
    [Key]
    public int ProductId { get; set; }

    [Key]
    [EmailAddress]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }

    [StringLength(500)]
    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;
}
