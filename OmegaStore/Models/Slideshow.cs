using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Slideshow
{
    public int Id { get; set; }
    public string Image { get; set; } = null!;
    public string Link { get; set; } = null!;
}

