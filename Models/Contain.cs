using System;
using System.Collections.Generic;

namespace FirstApi2.Models;

public partial class Contain
{
    public int Pid { get; set; }

    public string Passportno { get; set; } = null!;

    public int Ticketno { get; set; }

    public string Flightcode { get; set; } = null!;
}
