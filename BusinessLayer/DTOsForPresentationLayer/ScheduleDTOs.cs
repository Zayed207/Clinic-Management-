namespace DataLayer.Entities
{
    public class ScheduleRequestDTOs
    {
        public int ScheduleID { get; set; }
        public int EmployeeID_FK { get; set; }

        public EmployeeEntity Employee { get; set; }
        public DateTime ScheduleDate { get; set; }
        
        public DateTime ActualStartTime { get; set; }
        public DateTime ActualEndTime { get; set; }
    }

    public class ScheduleResponseDTOs
    {
        public int ScheduleID { get; set; }
        public int EmployeeID_FK { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeTypeName { get; set; }
        public DateTime ScheduleDate { get; set; }

        public DateTime ActualStartTime { get; set; }
        public DateTime ActualEndTime { get; set; }

        public ScheduleResponseDTOs(int scheduleID, int employeeID_FK, string employeeName,
            string employeeTypeName, DateTime scheduleDate, DateTime actualStartTime, DateTime actualEndTime)
        {
            ScheduleID = scheduleID;
            EmployeeID_FK = employeeID_FK;
            EmployeeName = employeeName;
            EmployeeTypeName = employeeTypeName;
            ScheduleDate = scheduleDate;
            ActualStartTime = actualStartTime;
            ActualEndTime = actualEndTime;
        }
    }
}


