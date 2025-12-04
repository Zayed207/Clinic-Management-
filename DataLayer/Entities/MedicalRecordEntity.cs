using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class MedicalRecordEntity
{
    public int MRID{ get; set; }

    public int PatientID_FK { get; set; }

    public string BloodType { get; set; } = null!;

    public string ChronicDiseases { get; set; } = null!;

    public DateOnly IssueDate { get; set; }

    public string Notes { get; set; } = null!;

    public virtual PatientEntity Patient{ get; set; } = null!;
}
