using BusinessLayer;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;
using static AppointmentStatus;
using static AppointmentType;
using static BusinessLayer.ConsultationMode;

namespace DataLayer.Entities
{
    public class AppointmentRequestDTO
    {
        [Required]
        public int Patient_ID_FK { get; set; }
        [Required]
        public int Doctor_ID_FK { get; set; }
        [Required]
        public int Clinic_ID_FK { get; set; }
        [Required]
        public DateTime Appointment_Date_Time { get; set; }
        public int ?Appointment_Duration_Minutes  { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enAppointmentStatus Status_ID_FK { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enAppointmentType Appointment_Type_ID_FK { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enConsultationType? Consultation_Mode_ID_FK { get; set; }
      
        public string? Notes { get; set; }

        // Relations
        

    }
    public class AppointmentResposeDTO
    {
        public int Appointment_ID { get; set; }
        public int Patient_ID { get; set; }
        public string PatientName { get; set; }
        public int DoctorID{ get; set; }

        public string DoctorName { get; set; }
        public int ClinicID { get; set; }
        public string ClinicName { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public int? AppointmentDurationMinutes { get; set; }
        public int? AppoinmentStatus{ get; set; }
        public int AppointmentTypeName{ get; set; }
        public int? ConsultationMode { get; set; }

        public string? Notes { get; set; }

        // Relations


    }


}


