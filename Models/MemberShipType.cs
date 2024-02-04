using System;
using System.Collections.Generic;

namespace Leif_Gym_Manager.Models;

public partial class MemberShipType
{
    public int MemberShipTypeId { get; set; }

    public decimal Price { get; set; }

    public string Frequency { get; set; } = null!;

    public string MemberShipName { get; set; } = null!;

    public string ContactTerm { get; set; } = null!;

    public int MinimumAge { get; set; }

    public int MaximumAge { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
