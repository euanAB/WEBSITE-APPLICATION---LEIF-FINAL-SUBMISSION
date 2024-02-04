using System;
using System.Collections.Generic;

namespace Leif_Gym_Manager.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public int StaffId { get; set; }

    public string ClassName { get; set; } = null!;

    public DateTime Time { get; set; }

    public string Day { get; set; } = null!;

    public string Capacity { get; set; } = null!;

    public string Field { get; set; } = null!;

    public int Location { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AppointmentManager> AppointmentManagers { get; set; } = new List<AppointmentManager>();

    public virtual Staff Staff { get; set; } = null!;
}
