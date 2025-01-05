using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Blog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string Thumbnail { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string Slug { get; set; } = null!;

    [Required]
    public string Content { get; set; } = null!;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;
}
