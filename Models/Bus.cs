using System;
using System.Collections.Generic;

namespace Assignment_BusApplication.Models;

public partial class Bus
{
    public int BusId { get; set; }

    public string BusNumber { get; set; } = null!;

    public string DriverName { get; set; } = null!;

    public long DriverNumber { get; set; }
}
