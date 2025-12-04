using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class PaymentEntity
{
    public int PaymentID { get; set; }

    public int AppointmentID_FK { get; set; }

    public int DoctorID_FK { get; set; }

    public int PatientPersonID_FK{ get; set; }

    public short ProviderID_FK { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual AppointmentEntity Appointment{ get; set; } = null!;

    public virtual DoctorEntity? Doctor{ get; set; }

    public virtual PersonEntity? PatientPersonID{ get; set; }

    public virtual PaymentProviderEntity? Provider { get; set; }
}
