using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string OrderCode { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string Fullname { get; set; } = null!;

    [Required]
    [EmailAddress]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string Address { get; set; } = null!;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal TotalAmount { get; set; }

    [Required]
    public bool PaymentMethod { get; set; }

    [Required]
    public int Status { get; set; }

    public virtual ICollection<DetailOrder> DetailOrders { get; set; } = new List<DetailOrder>();
}
