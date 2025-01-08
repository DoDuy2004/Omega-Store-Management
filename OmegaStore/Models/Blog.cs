using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmegaStore.Models;

public partial class Blog
{
    public int Id { get; set; }
	public string Author { get; set; } = null!;
	public string Title { get; set; } = null!;
    public string Thumbnail { get; set; } = null!;
    public string Slug { get; set; } = null!;
	public string ListContent { get; set; } = null!;
	public string ShortContent { get; set; } = null!;
	public string Content { get; set; } = null!;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
}

