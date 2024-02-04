using System;
using System.Collections.Generic;

namespace Leif_Gym_Manager.Models;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string PaymentMethods { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
