using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class EmployeeTypeEntity
{
    public short EmployeeTypeID{ get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
}
