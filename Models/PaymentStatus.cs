using System;
using System.Collections.Generic;

namespace Leif_Gym_Manager.Models;

public partial class PaymentStatuss
{
    public int PaymentStatusId { get; set; }

    public string PaymentStatus1 { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
