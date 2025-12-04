using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class AppointmentTypeEntity
{
    public int TypeID { get; set; }

    public string TypeName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<AppointmentEntity> Appointments { get; set; } = new List<AppointmentEntity>();
}
