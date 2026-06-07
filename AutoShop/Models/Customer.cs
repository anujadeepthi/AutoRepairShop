using System;
using System.Collections.Generic;

namespace AutoShop.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Address { get; set; }

    public string? Zip { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }
}
