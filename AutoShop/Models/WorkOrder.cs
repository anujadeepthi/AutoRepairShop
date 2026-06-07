using System;
using System.Collections.Generic;

namespace AutoShop.Models;

public partial class WorkOrder
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int VehicleId { get; set; }

    public string? IssueReported { get; set; }

    public string? ServiceType { get; set; }

    public string? Status { get; set; }

    public string? Comments { get; set; }
}
