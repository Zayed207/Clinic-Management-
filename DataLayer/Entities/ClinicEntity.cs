using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class ClinicEntity
{
    public int ClinicID{ get; set; }

    public string ClinicName { get; set; } = null!;

    public string LocationDescription { get; set; } = null!;

    public TimeOnly Start { get; set; }

    public TimeOnly End { get; set; }

    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;

    public bool Available { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<AppointmentEntity> Appointments { get; set; } = new List<AppointmentEntity>();

    public virtual ICollection<EmployeeEntity> Employees{ get; set; } = new List<EmployeeEntity>();


}
