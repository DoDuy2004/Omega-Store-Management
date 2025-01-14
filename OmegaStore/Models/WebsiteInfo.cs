using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class WebsiteInfo
{
    public int Id { get; set; }
    public string? ContactInfo { get; set; }
    public string? Map { get; set; }
    public string? Fanpage { get; set; }
    public string? Logo { get; set; }

    [NotMapped]
	public IFormFile? LogoUpload { get; set; }
}

