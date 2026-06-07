using System;
using System.Collections.Generic;

namespace AutoShop.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public string Vin { get; set; } = null!;

    public int Cust_Id { get; set; } = 0;
}
