using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class ProductsImage
{
    public int ProductId { get; set; }
    public string Image { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

