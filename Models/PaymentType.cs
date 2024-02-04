using System;
using System.Collections.Generic;

namespace Leif_Gym_Manager.Models;

public partial class PaymentType
{
    public int PaymentId { get; set; }

    public string PaymentAmount { get; set; } = null!;

    public string Method { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Membersname { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
