using System;
using System.Collections.Generic;

namespace AtividadeWeb1.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? PostalCode { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? MembershipStatus { get; set; }

    public DateTime? JoinDate { get; set; }

    public DateTime? LastPurchaseDate { get; set; }

    public string? TotalSpending { get; set; }

    public string? AverageOrderValue { get; set; }

    public string? Frequency { get; set; }

    public string? PreferredCategory { get; set; }

    public string? Churned { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
