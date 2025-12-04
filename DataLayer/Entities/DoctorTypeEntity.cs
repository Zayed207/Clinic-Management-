using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class DoctorTypeEntity
{
    public short DoctorTypeID{ get; set; }

    public string TypeName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<DoctorEntity> Doctors { get; set; } = new List<DoctorEntity>();
}
