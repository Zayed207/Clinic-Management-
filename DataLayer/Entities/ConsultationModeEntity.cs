using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class ConsultationModeEntity
{
    public int ModeID { get; set; }

    public string ModeName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<AppointmentEntity> Appointments { get; set; } = new List<AppointmentEntity>();
}
