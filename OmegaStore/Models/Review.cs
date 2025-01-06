using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Review
{
    public int ProductId { get; set; }
    public string Email { get; set; } = null!;
    public string Fullname { get; set; } = null!;
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public virtual Product Product { get; set; } = null!;
}

