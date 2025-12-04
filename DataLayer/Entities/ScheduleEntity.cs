using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class ScheduleEntity
{
    public int ScheduleID { get; set; }

    public int EmployeeID_FK { get; set; }
    public DateOnly ScheduleDate { get; set; }

    public TimeOnly ActualStartTime { get; set; }

    public TimeOnly ActualEndTime { get; set; }

    public EmployeeEntity? Employee { get; set; }
}
