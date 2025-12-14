using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

using static BusinessLayer.Appointment;


namespace BusinessLayer.DTOsPresentation.AppoinntmentsDTOs
{
    public class AppointmentRequestDTO
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int ClinicID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public short AppointmentDurationMinutes { get; set; }
        public enAppointmentStatus StatusID { get; set; }
        public enAppointmentType  AppointmentTypeID { get; set; }
        public enConsultationType ConsultationModeID { get; set; }

        public string? Notes { get; set; }

        public AppointmentRequestDTO(int appointmentID, int patientID, int doctorID, int clinicID, DateTime appointmentDateTime, short appointmentDurationMinutes, enAppointmentStatus statusID, 
            enAppointmentType appointmentTypeID, enConsultationType consultationModeID, string? notes)
        {
            AppointmentID = appointmentID;
            PatientID = patientID;
            DoctorID = doctorID;
            ClinicID = clinicID;
            AppointmentDateTime = appointmentDateTime;
            AppointmentDurationMinutes = appointmentDurationMinutes;
            StatusID = statusID;
            AppointmentTypeID = appointmentTypeID;
            ConsultationModeID = consultationModeID;
            Notes = notes;
        }
        


    }
    public class AppointmentResposeDTO
    {
        public int AppointmentID { get; set; }
        
        public string PatientName { get; set; }
       

        public string DoctorName { get; set; }

        public string ClinicName { get; set; } 
        public DateTime AppointmentDateTime { get; set; }
        public short AppointmentDurationMinutes { get; set; }
        public string AppoinmentStatus{ get; set; }
        public string AppointmentTypeName{ get; set; }
        

        public string? Notes { get; set; }

        public AppointmentResposeDTO(AppointmentResposeEntity e)
        {
            AppointmentID = e.AppointmentID;
            PatientName = e.PatientName;
            DoctorName = e.DoctorName;
            ClinicName = e.ClinicName;
            AppointmentDateTime = e.AppointmentDateTime;
            AppointmentDurationMinutes = e.AppointmentDurationMinutes;
            AppoinmentStatus = e.AppoinmentStatus;
            AppointmentTypeName = e.AppointmentTypeName;
            Notes = e.Notes;
        }

        public static List<AppointmentResposeDTO> ConvertAppointmentResposeEntityToDTO(List<AppointmentResposeEntity >appointments)
        {
            var Appointments = new List<AppointmentResposeDTO>();

            foreach (var entity in appointments)
            {
                Appointments.Add(new AppointmentResposeDTO(entity));

            }
            return Appointments;
        }
    }

    public class AppointmentsDetailsDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public short? Age { get; set; }


        public string BloodType { get; set; }
        public string ChronicDiseases { get; set; }
        public DateOnly IssueDate { get; set; }


        public DateTime AppointmentHour { get; set; }
        public string AppointmentTypeName { get; set; }
        public string AppointmentStatusName { get; set; }
        public string? Notes { get; set; }

       

        public AppointmentsDetailsDTO(AppointmentsDetails a)
        {
            FirstName = a.FirstName;
            LastName = a.LastName;
            Phone = a.Phone;
            Age      = a.Age;
            BloodType = a.BloodType;
            ChronicDiseases =  a.ChronicDiseases;
            IssueDate =           a.IssueDate;
            AppointmentHour =  a.AppointmentHour;
            AppointmentTypeName = a.AppointmentTypeName;
            AppointmentStatusName = a.AppointmentStatusName;
            Notes = a.Notes;
        }
    }

}


