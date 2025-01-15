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

    [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Số điện thoại không được bỏ trống.")]
    [RegularExpression(@"^(0[1-9]{1}[0-9]{8}|0[1-9]{2}[0-9]{7})$",
        ErrorMessage = "Số điện thoại không hợp lệ.")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Địa chỉ không được bỏ trống.")]
    public string Address { get; set; } = null!;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public decimal TotalAmount { get; set; }
    public bool PaymentMethod { get; set; }
    public string? Note { get; set; }
    public int Status { get; set; }

    // Thêm AccountId làm khóa ngoại
    public int AccountId { get; set; }

    // Mối quan hệ với Account
    public virtual Account? Account { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<DetailOrder>? DetailOrders { get; set; } = new List<DetailOrder>();
}

