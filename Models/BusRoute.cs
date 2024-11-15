using System;
using System.Collections.Generic;

namespace Assignment_BusApplication.Models;

public partial class BusRoute
{
    public int RouteId { get; set; }

    public string StartLocation { get; set; } = null!;

    public string EndLocation { get; set; } = null!;

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public int SeatCapacity { get; set; }

    public int? SeatAvailability { get; set; }

    public decimal Price { get; set; }

    public int BusId { get; set; }
}
