using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstApi2.Models;

public partial class Airport
{
    public string ApName { get; set; } = null!;

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }
}
