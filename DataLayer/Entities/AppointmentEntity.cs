using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public class AppointmentsDetails
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

}
public partial class AppointmentEntity
{
    public int Appointment_ID { get; set; }

    public int PatientID_FK { get; set; }

    public int DoctorID_FK { get; set; }

    public int ClinicID_FK { get; set; }

    public DateTime AppointmentDateTime{ get; set; }

   
    public short AppointmentDurationMinutes { get; set; }

    public int StatusID_FK { get; set; }

    public int AppointmentTypeID_FK { get; set; }

    public int ConsultationModeID_FK { get; set; }

    public string? Notes { get; set; }

    public virtual AppointmentTypeEntity AppointmentType{ get; set; } = null!;

    public virtual ClinicEntity Clinic{ get; set; } = null!;

    public virtual ConsultationModeEntity ConsultationMode{ get; set; } = null!;

    public virtual DoctorEntity Doctor{ get; set; } = null!;

    public virtual PatientEntity Patient{ get; set; } = null!;

    public virtual PaymentEntity? Payment { get; set; }

    public virtual AppointmentStatusEntity Status{ get; set; } = null!;
}
