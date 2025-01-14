﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Contact
{

    public int ContactId { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập email của bạn!")]
    [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập tên của bạn")]
    public string Fullname { get; set; } = null!;

    [Required(ErrorMessage = "Nhập chủ đề bạn cần hỗ trợ")]
    public string Subject { get; set; } = null!;
    public string? Message { get; set; } = null!;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public RequestStatus Status { get; set; } = RequestStatus.Unresolved;
    public string? OrderCode { get; set; }
}

public enum RequestStatus
{
    Resolved = 1,  // Đã giải quyết
    Unresolved = 0 // Chưa giải quyết
}