using System;
using System.Collections.Generic;

namespace AutoShop.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? EmployeeName { get; set; }

    public string? Role { get; set; }

    public string? EmpId { get; set; }

    public string? Password { get; set; }
}
