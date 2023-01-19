using System;
using System.Collections.Generic;

namespace FirstApi2.Models;

public partial class Passenger2
{
    public string Passportno { get; set; } = null!;

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Address { get; set; }

    public int? Age { get; set; }

    public string? Sex { get; set; }
}
