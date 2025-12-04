using DataLayer.Entities;

namespace BusinessLayer
{
    public class Schedule
    {
        public int ScheduleID { get; set; }

        public int EmployeeID_FK { get; set; }
        public DateOnly ScheduleDate { get; set; }

        public TimeOnly ActualStartTime { get; set; }

        public TimeOnly ActualEndTime { get; set; }

    }
}


