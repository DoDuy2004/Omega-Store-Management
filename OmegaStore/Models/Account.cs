using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Account
{
    public int Id { get; set; }
    public string Fullname { get; set; } = null!;
    public bool Gender { get; set; }
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Address { get; set; } = null!;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public int RoleId { get; set; }
    public int Status { get; set; }
    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}

