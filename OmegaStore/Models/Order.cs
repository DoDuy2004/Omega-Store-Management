using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Order
{
    public int Id { get; set; }
    public string OrderCode { get; set; } = null!;
    public string Fullname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public decimal TotalAmount { get; set; }
    public bool PaymentMethod { get; set; }
    public int Status { get; set; }

    // Thêm AccountId làm khóa ngoại
    public int AccountId { get; set; }

    // Mối quan hệ với Account
    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<DetailOrder> DetailOrders { get; set; } = new List<DetailOrder>();
}

