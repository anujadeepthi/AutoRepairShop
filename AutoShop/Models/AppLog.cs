using System;
using System.Collections.Generic;

namespace AutoShop.Models;

public partial class AppLog
{
    public int Id { get; set; }
    public DateTime LogDate { get; set; }
    public string Message { get; set; }
    public string LoginId { get; set; }



}
