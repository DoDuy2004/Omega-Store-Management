using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Contact
{
    [Key]
    [EmailAddress]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string Fullname { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string Subject { get; set; } = null!;

    [Required]
    [StringLength(500)]
    public string Message { get; set; } = null!;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public int Status { get; set; }
}
