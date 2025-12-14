using DataLayer.ReadModel.Appointment;


namespace BusinessLayer.DTOsPresentation.AppoinntmentsDTOs
{
    public class AppointmentCalendarDTO
    {
        public int AppointmentID { get; set; }
        public string Patient{ get; set; }
        public string Doctor{ get; set; }
        public string Clinic{ get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public short AppointmentDurationMinutes { get; set; }
        public string AppointmentStatus { get; set; }
        public string AppointmentType{ get; set; }
        public string? Notes { get; set; }

        public AppointmentCalendarDTO(AppointmentCalendar entity)
        {
            AppointmentID = entity.AppointmentID;
            Patient= entity.PatientName;
            Doctor = entity.DoctorName;
            Clinic = entity.ClinicName;
            AppointmentDateTime = entity.AppointmentDateTime;
            AppointmentDurationMinutes = entity.AppointmentDurationMinutes;
            AppointmentStatus = entity.AppoinmentStatus;
            AppointmentType= entity.AppointmentType;
            Notes = entity.Notes;
        }

        public static List<AppointmentCalendarDTO> FromEntities(
            List<AppointmentCalendar> entities)
        {
            return entities
                .Select(e => new AppointmentCalendarDTO(e))
                .ToList();
        }
    }

}


