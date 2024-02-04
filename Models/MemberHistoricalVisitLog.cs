using System;
using System.Collections.Generic;

namespace Leif_Gym_Manager.Models;

public partial class MemberHistoricalVisitLog
{
    public int HistoricalVisitLogId { get; set; }

    public string FobNumber { get; set; } = null!;

    public DateTime CheckOut { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Member FobNumberNavigation { get; set; } = null!;
}
