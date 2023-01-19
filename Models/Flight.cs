using System;
using System.Collections.Generic;

namespace FirstApi2.Models;

public partial class Flight
{
    public string Flightcode { get; set; } = null!;

    public string? Source { get; set; }

    public string? Destination { get; set; }

    public string? Arrival { get; set; }

    public string? Departure { get; set; }
}
