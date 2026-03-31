using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class UserEntity
{
    public int UserID { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public short RoleID_FK { get; set; }

    public bool IsActive { get; set; }

    public string RefreshTokenHash { get; set; }
    public DateTime? RefreshTokenExpiresAt { get; set; }
    public DateTime? RefreshTokenRevokedAt { get; set; }
    public virtual EmployeeEntity? Employees { get; set; } 

    public virtual PatientEntity? Patient { get; set; }
}
