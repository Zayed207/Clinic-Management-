using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class newschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentStatus",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStatus", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentType",
                columns: table => new
                {
                    TypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentType", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    ClinicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationDescription = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Start = table.Column<TimeOnly>(type: "time(0)", nullable: false),
                    End = table.Column<TimeOnly>(type: "time(0)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.ClinicID);
                });

            migrationBuilder.CreateTable(
                name: "ConsultationModes",
                columns: table => new
                {
                    ModeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationModes", x => x.ModeID);
                });

            migrationBuilder.CreateTable(
                name: "DoctorTypes",
                columns: table => new
                {
                    DoctorTypeID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorTypes", x => x.DoctorTypeID);
                });

            migrationBuilder.CreateTable(
                name: "employeeTypes",
                columns: table => new
                {
                    EmployeeTypeID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeTypes", x => x.EmployeeTypeID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentProviders",
                columns: table => new
                {
                    ProviderID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ProviderType = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentProviders", x => x.ProviderID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ThirdName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Age = table.Column<short>(type: "smallint", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RoleID_FK = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpployeeTypeID_FK = table.Column<short>(type: "smallint", nullable: false),
                    ClinicID_FK = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PersonID_FK = table.Column<int>(type: "int", nullable: false),
                    NationalID = table.Column<string>(type: "varchar(50)", nullable: false),
                    UserID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Clinic_ClinicID_FK",
                        column: x => x.ClinicID_FK,
                        principalTable: "Clinic",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Person_PersonID_FK",
                        column: x => x.PersonID_FK,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserID_FK",
                        column: x => x.UserID_FK,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_employeeTypes_EmpployeeTypeID_FK",
                        column: x => x.EmpployeeTypeID_FK,
                        principalTable: "employeeTypes",
                        principalColumn: "EmployeeTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientPersonID_FK = table.Column<int>(type: "int", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    RegisterDatew = table.Column<DateOnly>(type: "date", nullable: false),
                    UserID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patient_Person_PatientPersonID_FK",
                        column: x => x.PatientPersonID_FK,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_Users_UserID_FK",
                        column: x => x.UserID_FK,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID_FK = table.Column<int>(type: "int", nullable: false),
                    MedicalLicenseNumber = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    YearsOfExperience = table.Column<short>(type: "smallint", nullable: true),
                    IsOnCall = table.Column<bool>(type: "bit", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    DoctorTypeID_FK = table.Column<short>(type: "smallint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctor_DoctorTypes_DoctorTypeID_FK",
                        column: x => x.DoctorTypeID_FK,
                        principalTable: "DoctorTypes",
                        principalColumn: "DoctorTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctor_Employees_EmployeeID_FK",
                        column: x => x.EmployeeID_FK,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID_FK = table.Column<int>(type: "int", nullable: false),
                    ScheduleDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ActualStartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ActualEndTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_Schedule_Employees_EmployeeID_FK",
                        column: x => x.EmployeeID_FK,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecord",
                columns: table => new
                {
                    MRID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID_FK = table.Column<int>(type: "int", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ChronicDiseases = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    IssueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecord", x => x.MRID);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_Patient_PatientID_FK",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Appointment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID_FK = table.Column<int>(type: "int", nullable: false),
                    DoctorID_FK = table.Column<int>(type: "int", nullable: false),
                    ClinicID_FK = table.Column<int>(type: "int", nullable: false),
                    AppointmentDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    AppointmentDurationMinutes = table.Column<short>(type: "smallint", nullable: false),
                    StatusID_FK = table.Column<int>(type: "int", nullable: false),
                    AppointmentTypeID_FK = table.Column<int>(type: "int", nullable: false),
                    ConsultationModeID_FK = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Appointment_ID);
                    table.ForeignKey(
                        name: "FK_Appointment_AppointmentStatus_StatusID_FK",
                        column: x => x.StatusID_FK,
                        principalTable: "AppointmentStatus",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_AppointmentType_AppointmentTypeID_FK",
                        column: x => x.AppointmentTypeID_FK,
                        principalTable: "AppointmentType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Clinic_ClinicID_FK",
                        column: x => x.ClinicID_FK,
                        principalTable: "Clinic",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_ConsultationModes_ConsultationModeID_FK",
                        column: x => x.ConsultationModeID_FK,
                        principalTable: "ConsultationModes",
                        principalColumn: "ModeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_DoctorID_FK",
                        column: x => x.DoctorID_FK,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientID_FK",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentID_FK = table.Column<int>(type: "int", nullable: false),
                    DoctorID_FK = table.Column<int>(type: "int", nullable: false),
                    PatientPersonID_FK = table.Column<int>(type: "int", nullable: false),
                    ProviderID_FK = table.Column<short>(type: "smallint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_Appointment_AppointmentID_FK",
                        column: x => x.AppointmentID_FK,
                        principalTable: "Appointment",
                        principalColumn: "Appointment_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Doctor_DoctorID_FK",
                        column: x => x.DoctorID_FK,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentProviders_ProviderID_FK",
                        column: x => x.ProviderID_FK,
                        principalTable: "PaymentProviders",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Person_PatientPersonID_FK",
                        column: x => x.PatientPersonID_FK,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointmentTypeID_FK",
                table: "Appointment",
                column: "AppointmentTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ClinicID_FK",
                table: "Appointment",
                column: "ClinicID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ConsultationModeID_FK",
                table: "Appointment",
                column: "ConsultationModeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorID_FK",
                table: "Appointment",
                column: "DoctorID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientID_FK",
                table: "Appointment",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_StatusID_FK",
                table: "Appointment",
                column: "StatusID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_DoctorTypeID_FK",
                table: "Doctor",
                column: "DoctorTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_EmployeeID_FK",
                table: "Doctor",
                column: "EmployeeID_FK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ClinicID_FK",
                table: "Employees",
                column: "ClinicID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmpployeeTypeID_FK",
                table: "Employees",
                column: "EmpployeeTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonID_FK",
                table: "Employees",
                column: "PersonID_FK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserID_FK",
                table: "Employees",
                column: "UserID_FK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_PatientID_FK",
                table: "MedicalRecord",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PatientPersonID_FK",
                table: "Patient",
                column: "PatientPersonID_FK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_UserID_FK",
                table: "Patient",
                column: "UserID_FK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AppointmentID_FK",
                table: "Payment",
                column: "AppointmentID_FK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_DoctorID_FK",
                table: "Payment",
                column: "DoctorID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PatientPersonID_FK",
                table: "Payment",
                column: "PatientPersonID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ProviderID_FK",
                table: "Payment",
                column: "ProviderID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_EmployeeID_FK",
                table: "Schedule",
                column: "EmployeeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalRecord");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "PaymentProviders");

            migrationBuilder.DropTable(
                name: "AppointmentStatus");

            migrationBuilder.DropTable(
                name: "AppointmentType");

            migrationBuilder.DropTable(
                name: "ConsultationModes");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "DoctorTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "employeeTypes");
        }
    }
}
