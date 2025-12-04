using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class PersonEntity
{
    public int PersonID { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public string ThirdName { get; set; } = null!;
    public string SecondName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Country { get; set; } = null!;

    public short? Age { get; set; }

    public string FullName { get; set; } = null!;

    public char Gender { get; set; }
    public virtual EmployeeEntity? Employee { get; set; }

    public virtual PatientEntity? Patient { get; set; }

    public virtual ICollection<PaymentEntity> Payments { get; set; } = new List<PaymentEntity>();
}
