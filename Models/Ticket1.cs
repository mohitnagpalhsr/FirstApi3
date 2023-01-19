using System;
using System.Collections.Generic;

namespace FirstApi2.Models;

public partial class Ticket1
{
    public int Ticketno { get; set; }

    public string? Source { get; set; }

    public string? Destination { get; set; }

    public DateTime? DateOfBooking { get; set; }

    public DateTime? DateOfTravel { get; set; }

    public string? Class { get; set; }

    public int? Pid { get; set; }
}
