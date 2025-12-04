using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class PatientEntity
{
    public int PatientID { get; set; }

    public int PatientPersonID_FK { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public DateOnly RegisterDatew { get; set; }

    public int? UserID_FK { get; set; }

    public virtual ICollection<AppointmentEntity> Appointments { get; set; } = new List<AppointmentEntity>();

    public virtual ICollection<MedicalRecordEntity> MedicalRecords { get; set; } = new List<MedicalRecordEntity>();

    public virtual PersonEntity PatientPerson { get; set; } = null!;

    public virtual UserEntity? User{ get; set; }
}
