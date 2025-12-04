using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class AppointmentStatusEntity
{
    public int StatusID { get; set; }

    public string StatusName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<AppointmentEntity> Appointments { get; set; } = new List<AppointmentEntity>();
}
