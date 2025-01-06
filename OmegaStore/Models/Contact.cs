using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Contact
{
    public string Email { get; set; } = null!;
    public string Fullname { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Message { get; set; } = null!;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public int Status { get; set; }
}

