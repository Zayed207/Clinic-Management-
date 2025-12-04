using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class EmployeeEntity
{
    public int EmployeeID { get; set; }

    public short EmpployeeTypeID_FK { get; set; }

    public int ClinicID_FK { get; set; }
    public string Title { get; set; } = null!;

    public int PersonID_FK { get; set; }

    public string NationalID { get; set; } = null!;

    public int UserID_FK { get; set; }

    public virtual DoctorEntity? Doctor { get; set; }

    public virtual EmployeeTypeEntity EmpployeeType{ get; set; } = null!;

    public virtual ClinicEntity? Clinic{ get; set; }
    public virtual ICollection< ScheduleEntity> Schedules{ get; set; }=new List< ScheduleEntity>();

    public virtual PersonEntity Person{ get; set; } = null!;

    public virtual UserEntity User{ get; set; } = null!;
}
