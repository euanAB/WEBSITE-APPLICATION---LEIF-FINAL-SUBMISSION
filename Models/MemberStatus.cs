using System;
using System.Collections.Generic;

namespace Leif_Gym_Manager.Models;

public partial class MemberStatuss
{
    public int MemberStatusId { get; set; }

    public string MemberStatus1 { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
