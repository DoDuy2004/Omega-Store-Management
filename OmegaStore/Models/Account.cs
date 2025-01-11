using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Account
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
    [StringLength(100, ErrorMessage = "Họ và tên không được vượt quá 100 ký tự.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Họ và tên chỉ được chứa chữ cái.")]
    public string Fullname { get; set; } = null!;
    [Required(ErrorMessage = "Giới tính là bắt buộc.")]
    public bool Gender { get; set; }

    [Required(ErrorMessage = "Email là bắt buộc.")]
    [StringLength(50, ErrorMessage = "Email không được vượt quá 50 ký tự.")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
    [StringLength(20, ErrorMessage = "Số điện thoại không được vượt quá 20 ký tự.")]
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
    public string Phone { get; set; } = null!;
    [Required(ErrorMessage = "Tên tài khoản là bắt buộc.")]
    [StringLength(50, ErrorMessage = "Tên tài khoản không được vượt quá 50 ký tự.")]
    [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Tên tài khoản chỉ được chứa chữ cái và số.")]
    public string Username { get; set; } = null!;
    [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
    [StringLength(255, ErrorMessage = "Mật khẩu không được vượt quá 255 ký tự.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    public string Address { get; set; } = null!;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public int RoleId { get; set; }
    public int Status { get; set; }
    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}

