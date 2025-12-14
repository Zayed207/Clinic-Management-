namespace BusinessLayer.DTOsPresentation
{
    public class ScheduleRequestDTOs
    {
        
       

    
        public DateOnly ScheduleDate { get; set; }
        
        public TimeOnly ActualStartTime { get; set; }
        public TimeOnly ActualEndTime { get; set; }
    }

    public class ScheduleResponseDTOs
    {
        public int ScheduleID { get; set; }
      

        public string EmployeeName { get; set; }

        public string EmployeeTypeName { get; set; }
        public DateOnly ScheduleDate { get; set; }

        public TimeOnly ActualStartTime { get; set; }
        public TimeOnly ActualEndTime { get; set; }

        public ScheduleResponseDTOs(int scheduleID, int employeeID_FK, string employeeName,
            string employeeTypeName, DateOnly scheduleDate, TimeOnly actualStartTime, TimeOnly actualEndTime)
        {
            ScheduleID = scheduleID;
          
            EmployeeName = employeeName;
            EmployeeTypeName = employeeTypeName;
            ScheduleDate = scheduleDate;
            ActualStartTime = actualStartTime;
            ActualEndTime = actualEndTime;
        }
    }
}


