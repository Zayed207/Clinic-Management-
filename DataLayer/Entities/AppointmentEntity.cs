using System.Numerics;

namespace DataLayer.Entities
{
    public class AppointmentEntity
    {
        public int Appointment_ID { get; set; }
        public int Patient_ID_FK { get; set; }
        public int Doctor_ID_FK { get; set; }
        public int Clinic_ID_FK { get; set; }
        public DateTime Appointment_Date_Time { get; set; }
        public int ?Appointment_Duration_Minutes  { get; set; }
        public int ?Status_ID_FK { get; set; }
        public int Appointment_Type_ID_FK { get; set; }
        public int ?Consultation_Mode_ID_FK { get; set; }
      
        public string? Notes { get; set; }

        // Relations
        public PatientEntity Patient { get; set; }
        public DoctorEntity Doctor { get; set; }
        public ClinicEntity Clinic { get; set; }
        public AppointmentStatusEntity Status{ get; set; }
        public AppointmentTypeEntity AppointmentType { get; set; }
        public ConsultationModeEntity ConsultationMode { get; set; }

        public PaymentEntity Payment { get; set; }

    }

}


