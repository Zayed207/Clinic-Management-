using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class DoctorEntity
{
    public int DoctorID { get; set; }

    public int EmployeeID_FK { get; set; }

    public string MedicalLicenseNumber { get; set; } = null!;

    public short? YearsOfExperience { get; set; }

   

    public bool? IsOnCall { get; set; }

    public string Specialization { get; set; } = null!;

    public short DoctorTypeID_FK { get; set; }

    public decimal Price { get; set; }

    

    public virtual ICollection<AppointmentEntity> Appointments { get; set; } = new List<AppointmentEntity>();

    

    public virtual DoctorTypeEntity DoctorType{ get; set; } = null!;

    public virtual EmployeeEntity Employee{ get; set; } = null!;

    public virtual ICollection<PaymentEntity> Payments { get; set; } = new List<PaymentEntity>();
}
