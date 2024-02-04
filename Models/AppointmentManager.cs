using System;
using System.Collections.Generic;

namespace Leif_Gym_Manager.Models;

public partial class AppointmentManager
{
    public int AppointmentManagerId { get; set; }

    public int MemberId { get; set; }

    public int ClassId { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan Time { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
