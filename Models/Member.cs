using System;
using System.Collections.Generic;

namespace Leif_Gym_Manager.Models;

public partial class Member
{
    public int MembersId { get; set; }

    public string FobNumber { get; set; } = null!;

    public int MemberShipTypeId { get; set; }

    public int PaymentTypeId { get; set; }

    public int MemberStatusId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Ethinicity { get; set; } = null!;

    public string Religion { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string MedicalNotes { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public decimal Weight { get; set; }

    public decimal Height { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AppointmentManager> AppointmentManagers { get; set; } = new List<AppointmentManager>();

    public virtual MemberShipType MemberShipType { get; set; } = null!;

    public virtual PaymentType PaymentType { get; set; } = null!;
}
