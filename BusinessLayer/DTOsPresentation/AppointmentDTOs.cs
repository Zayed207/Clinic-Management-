using BusinessLayer;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;
using static AppointmentStatus;
using static AppointmentType;
using static BusinessLayer.Appointment;
using static BusinessLayer.ConsultationMode;

namespace DataLayer.Entities
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
        // Relations


    }
    public class AppointmentResposeDTO
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
       

        public string DoctorName { get; set; }

        public string ClinicName { get; set; } 
        public DateTime AppointmentDateTime { get; set; }
        public short AppointmentDurationMinutes { get; set; }
        public string AppoinmentStatus{ get; set; }
        public string AppointmentTypeName{ get; set; }
        public string ConsultationMode { get; set; }

        public string? Notes { get; set; }

        // Relations


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


