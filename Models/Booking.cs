using System;
using System.Collections.Generic;

namespace Assignment_BusApplication.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public string UserId { get; set; } = null!;

    public int RouteId { get; set; }

    public DateTime BookingDate { get; set; }

    public string SeatsBooked { get; set; } = null!;

    public string PassengerName { get; set; } = null!;

    public int Age { get; set; }
}
