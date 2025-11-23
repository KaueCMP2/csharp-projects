using System;
using System.Collections.Generic;

namespace AtividadeWeb1.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Category { get; set; }

    public string? Price { get; set; }

    public decimal? Cost { get; set; }

    public string? Description { get; set; }

    public string? Seasonal { get; set; }

    public string? Active { get; set; }

    public DateTime? IntroducedDate { get; set; }

    public string? Ingredients { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
