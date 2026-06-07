using System;
using System.Collections.Generic;

namespace AutoShop.Models;

public partial class CustVehicle
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? VehicleId { get; set; }
}
