using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Fullname { get; set; } = null!;

    [Required]
    public bool Gender { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string Password { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string Address { get; set; } = null!;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    [Required]
    [Display(Name = "Role")]
    public int RoleId { get; set; }

    [Required]
    public int Status { get; set; }

    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    public virtual Wishlist Wishlist { get; set; } = null!;
}
