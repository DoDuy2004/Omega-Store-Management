using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OmegaStore.Models;

public partial class Order
{
    public int Id { get; set; }
    public string OrderCode { get; set; } = null!;

    [Required(ErrorMessage = "Họ và tên không được bỏ trống.")]
    public string Fullname { get; set; } = null!;
    public string? Email { get; set; }
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Địa chỉ không được bỏ trống.")]
    public string Address { get; set; } = null!;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public decimal TotalAmount { get; set; }
    public bool PaymentMethod { get; set; }
    public string? Note { get; set; }
    public int Status { get; set; }

    // Thêm AccountId làm khóa ngoại
    public int? AccountId { get; set; }

    // Mối quan hệ với Account
    public virtual Account? Account { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<DetailOrder>? DetailOrders { get; set; } = new List<DetailOrder>();
}

