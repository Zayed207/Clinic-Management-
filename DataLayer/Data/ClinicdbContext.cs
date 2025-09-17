using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace DataLayer.Data
{
     public class Clinicdbcontext:DbContext
    {
        public Clinicdbcontext(DbContextOptions<Clinicdbcontext> options) : base(options)
        {
        }
        public DbSet<AccountEntity> Accounts { get; set; } = null;
        public DbSet<AppointmentEntity> Appointment { get; set; } = null;
        public DbSet<AppointmentStatusEntity> AppointmentStatus { get; set; } = null;
        public DbSet<AppointmentTypeEntity> AppointmentType { get; set; } = null;
        public DbSet<ClinicEntity> Clinic { get; set; } = null!;
        public DbSet<ConsultationModeEntity> ConsultationModes { get; set; } = null;
        public DbSet<DoctorEntity> Doctor { get; set; } = null;
        public DbSet<DoctorTypeEntity> DoctorTypes { get; set; } = null;

        public DbSet<EmployeeEntity> Employees { get; set; } = null!;

        public DbSet<EmployeeTypeEntity> employeeTypes { get; set; } = null;
        public DbSet<NurseEntity> Nurse { get; set; } = null!;
        public DbSet<PatientEntity> Patient { get; set; } = null!;
        public DbSet<PersonEntity> Person { get; set; } = null!;
       
        
        public DbSet<MedicalRecordEntity> MedicalRecord { get; set; } = null!;
        public DbSet<ScheduleEntity> Schedule { get; set; } = null!;



        public DbSet<PaymentEntity> Payment { get; set; } = null;
        
        public DbSet<PaymentProviderEntity> PaymentProviders { get; set; } = null;

        public DbSet<UserEntity> Users{ get; set; } = null;
        // public DbSet<ConsultationModeData> ConsultationMode{ get; set; } = null!;
        //public DbSet<PaymentEntity> Payment { get; set; } = null!;
        //public DbSet<ClincEntity> Clinic { get; set; } = null!;
        //public DbSet<ClincEntity> Clinic { get; set; } = null!;
        //public DbSet<ClincEntity> Clinic { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    var s=new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();

        //    var connection = s.GetSection("constr").Value;

        //    optionsBuilder.UseSqlServer(connection);

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Clinicdbcontext).Assembly);

        }
    }
}
