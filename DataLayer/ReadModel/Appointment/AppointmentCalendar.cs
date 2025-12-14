using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ReadModel.Appointment
{
    public  class AppointmentCalendar
    {
        public int AppointmentID { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string ClinicName { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public short AppointmentDurationMinutes { get; set; }
        public string AppoinmentStatus { get; set; }
        public string AppointmentType{ get; set; }
        public string? Notes { get; set; }
    }
}
