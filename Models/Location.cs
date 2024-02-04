using System;
using System.Collections.Generic;

namespace Leif_Gym_Manager.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string Location1 { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
