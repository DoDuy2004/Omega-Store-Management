using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Contact
{

    public int ContactId { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập email của bạn!")]
    [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ.")]
    [StringLength(100, ErrorMessage = "Email không vượt quá 100 kí tự.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập tên của bạn")]
    [StringLength(50, ErrorMessage = "Tên không được vượt quá 50 ký tự.")]
    public string Fullname { get; set; } = null!;

    [Required(ErrorMessage = "Nhập chủ đề bạn cần hỗ trợ")]
    [StringLength(200, ErrorMessage = "Chủ đề không được vượt quá 200 ký tự.")]
    public string Subject { get; set; } = null!;
    public string? Message { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public RequestStatus Status { get; set; } = RequestStatus.Unresolved;
    public string? OrderCode { get; set; }
    public string? ResponseMessage { get; set; }
}

public enum RequestStatus
{
    Resolved = 1,  // Đã giải quyết
    Unresolved = 0 // Chưa giải quyết
}