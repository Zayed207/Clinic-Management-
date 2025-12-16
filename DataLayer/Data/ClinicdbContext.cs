using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Contract;
using DataLayer.Entities;
using DataLayer.ReadModel.Appointment;
using DataLayer.ReadModel.Clinic;
using DataLayer.ReadModel.Doctor;
using DataLayer.ReadModel.Employee;
using DataLayer.ReadModel.MedicalRecord;
using DataLayer.ReadModel.Patient;
using DataLayer.ReadModel.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace DataLayer.Data
{
     public class Clinicdbcontext:DbContext
    {
        public Clinicdbcontext(DbContextOptions<Clinicdbcontext> options) : base(options)
        {
        }
       
        public DbSet<AppointmentEntity> Appointment { get; set; } = null;
        public DbSet<AppointmentStatusEntity> AppointmentStatus { get; set; } = null;
        public DbSet<AppointmentTypeEntity> AppointmentType { get; set; } = null;
        public DbSet<ClinicEntity> Clinic { get; set; } = null!;
        public DbSet<ConsultationModeEntity> ConsultationModes { get; set; } = null;
        public DbSet<DoctorEntity> Doctor { get; set; } = null;
        public DbSet<DoctorTypeEntity> DoctorTypes { get; set; } = null;

        public DbSet<EmployeeEntity> Employees { get; set; } = null!;

        public DbSet<EmployeeTypeEntity> employeeTypes { get; set; } = null;
        public DbSet<PatientEntity> Patient { get; set; } = null!;
        public DbSet<PersonEntity> Person { get; set; } = null!;
       
        
        public DbSet<MedicalRecordEntity> MedicalRecord { get; set; } = null!;
        public DbSet<ScheduleEntity> Schedule { get; set; } = null!;



        public DbSet<PaymentEntity> Payment { get; set; } = null;
        
        public DbSet<PaymentProviderEntity> PaymentProviders { get; set; } = null;

        public DbSet<UserEntity> Users{ get; set; } = null;

        // StoreProcedtuers
        public DbSet<AppointmentCalendar> AppointmentCalendar { get; set; }
        public DbSet<ClinicInfo> ClinicInfo{ get; set; }

        public DbSet<DoctorInfo> DoctorInfo { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public DbSet<MedicalRecordInfo> MedicalRecordInfo { get; set; }

        public DbSet<PatientInfo> PatientInfo { get; set; }
        public DbSet<PaymentInfo> PaymentInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Clinicdbcontext).Assembly);
         

        }
    }
}
