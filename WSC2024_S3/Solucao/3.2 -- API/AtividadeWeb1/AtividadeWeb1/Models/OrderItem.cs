using System;
using System.Collections.Generic;

namespace AtividadeWeb1.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? TransactionId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public string? Price { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Order? Transaction { get; set; }
}
