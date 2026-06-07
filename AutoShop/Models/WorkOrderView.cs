using System;
using System.Collections.Generic;

namespace AutoShop.Models;

public class WorkOrderView
{
    public WorkOrder WorkOrder { get; set; }
    public List<WorkOrderDetail> Details { get; set; }
}
