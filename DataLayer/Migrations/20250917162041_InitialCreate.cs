using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentStatus",
                columns: table => new
                {
                    Status_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStatus", x => x.Status_ID);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentType",
                columns: table => new
                {
                    Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentType", x => x.Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    ClinicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationDescription = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime", nullable: false),
                    End = table.Column<DateTime>(type: "datetime", nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", nullable: false)
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
                    Mode_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
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
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Permissions = table.Column<short>(type: "smallint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountProviderID_FK = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Accounts_PaymentProviders_AccountProviderID_FK",
                        column: x => x.AccountProviderID_FK,
                        principalTable: "PaymentProviders",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Age = table.Column<short>(type: "smallint", nullable: true),
                    UserID_FK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Person_Users_UserID_FK",
                        column: x => x.UserID_FK,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpployeeTypeID_FK = table.Column<short>(type: "smallint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PersonID_FK = table.Column<int>(type: "int", nullable: false),
                    NationalID = table.Column<string>(type: "varchar(50)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Person_PersonID_FK",
                        column: x => x.PersonID_FK,
                        principalTable: "Person",
                        principalColumn: "PersonID",
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
                    PatientPersonID = table.Column<int>(type: "int", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    RegisterDatew = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patient_Person_PatientPersonID",
                        column: x => x.PatientPersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_ID_FK = table.Column<int>(type: "int", nullable: false),
                    MedicalLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Years_of_Experience = table.Column<short>(type: "smallint", nullable: true),
                    ClinicID_FK = table.Column<int>(type: "int", nullable: false),
                    ClinicID = table.Column<int>(type: "int", nullable: false),
                    Is_On_Call = table.Column<bool>(type: "bit", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar", nullable: false),
                    DoctorTypeID_FK = table.Column<short>(type: "smallint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctor_Clinic_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "Clinic",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctor_DoctorTypes_DoctorTypeID_FK",
                        column: x => x.DoctorTypeID_FK,
                        principalTable: "DoctorTypes",
                        principalColumn: "DoctorTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctor_Employees_Employee_ID_FK",
                        column: x => x.Employee_ID_FK,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nurse",
                columns: table => new
                {
                    NurseID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_ID_FK = table.Column<int>(type: "int", nullable: false),
                    ClinicID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurse", x => x.NurseID);
                    table.ForeignKey(
                        name: "FK_Nurse_Clinic_ClinicID_FK",
                        column: x => x.ClinicID_FK,
                        principalTable: "Clinic",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nurse_Employees_Employee_ID_FK",
                        column: x => x.Employee_ID_FK,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID_FK = table.Column<int>(type: "int", nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ActualStartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ActualEndTime = table.Column<DateTime>(type: "datetime", nullable: false)
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
                    MRNID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID_FK = table.Column<int>(type: "int", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ChronicDiseases = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecord", x => x.MRNID);
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
                    Patient_ID_FK = table.Column<int>(type: "int", nullable: false),
                    Doctor_ID_FK = table.Column<int>(type: "int", nullable: false),
                    Clinic_ID_FK = table.Column<int>(type: "int", nullable: false),
                    Appointment_Date_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Appointment_Duration_Minutes = table.Column<int>(type: "int", nullable: true),
                    Status_ID_FK = table.Column<int>(type: "int", nullable: false),
                    Appointment_Type_ID_FK = table.Column<int>(type: "int", nullable: false),
                    Consultation_Mode_ID_FK = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Appointment_ID);
                    table.ForeignKey(
                        name: "FK_Appointment_AppointmentStatus_Status_ID_FK",
                        column: x => x.Status_ID_FK,
                        principalTable: "AppointmentStatus",
                        principalColumn: "Status_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_AppointmentType_Appointment_Type_ID_FK",
                        column: x => x.Appointment_Type_ID_FK,
                        principalTable: "AppointmentType",
                        principalColumn: "Type_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Clinic_Clinic_ID_FK",
                        column: x => x.Clinic_ID_FK,
                        principalTable: "Clinic",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_ConsultationModes_Consultation_Mode_ID_FK",
                        column: x => x.Consultation_Mode_ID_FK,
                        principalTable: "ConsultationModes",
                        principalColumn: "ModeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_Doctor_ID_FK",
                        column: x => x.Doctor_ID_FK,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_Patient_ID_FK",
                        column: x => x.Patient_ID_FK,
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
                    FromAccountID = table.Column<int>(type: "int", nullable: true),
                    ToAccountID = table.Column<int>(type: "int", nullable: true),
                    ProviderID = table.Column<short>(type: "smallint", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_Accounts_FromAccountID",
                        column: x => x.FromAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Accounts_ToAccountID",
                        column: x => x.ToAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Appointment_AppointmentID_FK",
                        column: x => x.AppointmentID_FK,
                        principalTable: "Appointment",
                        principalColumn: "Appointment_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentProviders_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "PaymentProviders",
                        principalColumn: "ProviderID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountProviderID_FK",
                table: "Accounts",
                column: "AccountProviderID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Appointment_Type_ID_FK",
                table: "Appointment",
                column: "Appointment_Type_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Clinic_ID_FK",
                table: "Appointment",
                column: "Clinic_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Consultation_Mode_ID_FK",
                table: "Appointment",
                column: "Consultation_Mode_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Doctor_ID_FK",
                table: "Appointment",
                column: "Doctor_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Patient_ID_FK",
                table: "Appointment",
                column: "Patient_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Status_ID_FK",
                table: "Appointment",
                column: "Status_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ClinicID",
                table: "Doctor",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_DoctorTypeID_FK",
                table: "Doctor",
                column: "DoctorTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Employee_ID_FK",
                table: "Doctor",
                column: "Employee_ID_FK",
                unique: true);

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
                name: "IX_MedicalRecord_PatientID_FK",
                table: "MedicalRecord",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Nurse_ClinicID_FK",
                table: "Nurse",
                column: "ClinicID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Nurse_Employee_ID_FK",
                table: "Nurse",
                column: "Employee_ID_FK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PatientPersonID",
                table: "Patient",
                column: "PatientPersonID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AppointmentID_FK",
                table: "Payment",
                column: "AppointmentID_FK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_FromAccountID",
                table: "Payment",
                column: "FromAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ProviderID",
                table: "Payment",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ToAccountID",
                table: "Payment",
                column: "ToAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserID_FK",
                table: "Person",
                column: "UserID_FK",
                unique: true,
                filter: "[UserID_FK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_EmployeeID_FK",
                table: "Schedule",
                column: "EmployeeID_FK",
                unique: true);

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
                name: "Nurse");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Accounts");

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
                name: "Clinic");

            migrationBuilder.DropTable(
                name: "DoctorTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "employeeTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
