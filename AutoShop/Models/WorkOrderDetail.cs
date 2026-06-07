using System;
using System.Collections.Generic;

namespace AutoShop.Models;

public partial class WorkOrderDetail
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? Cost { get; set; }

    public int? Line { get; set; }

    public int? WorkOrder_Id { get; set; }
}
