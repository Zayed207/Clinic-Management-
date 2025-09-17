using DataLayer.Entities;

namespace BusinessLayer
{
    public class ScheduleEntity
    {
        public int ScheduleID { get; set; }
        public int EmployeeID_FK { get; set; }

        public EmployeeEntity Employee { get; set; }
        public DateTime ScheduleDate { get; set; }
        
        public DateTime ActualStartTime { get; set; }
        public DateTime ActualEndTime { get; set; }
    }

}


