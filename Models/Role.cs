using System;
using System.Collections.Generic;

namespace Leif_Gym_Manager.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
