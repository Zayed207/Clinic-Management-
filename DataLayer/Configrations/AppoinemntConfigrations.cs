using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configrations
{
    public class AppoinemntConfigrations : IEntityTypeConfiguration<AppointmentEntity>
    {
        public void Configure(EntityTypeBuilder<AppointmentEntity> builder)
        {
      

        

        builder.HasKey(x => x.Appointment_ID);
            builder.Property(x => x.Appointment_ID).ValueGeneratedOnAdd().IsRequired();

            builder.HasOne(x => x.Doctor)
      .WithMany(d => d.Appointments)
      .HasForeignKey(x => x.DoctorID_FK)
      .IsRequired()
      .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Clinic)
                .WithMany(c => c.Appointments)
                .HasForeignKey(x => x.ClinicID_FK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(x => x.PatientID_FK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Status)
                .WithMany(s => s.Appointments)
                .HasForeignKey(x => x.StatusID_FK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AppointmentType)
                .WithMany(t => t.Appointments)
                .HasForeignKey(x => x.AppointmentTypeID_FK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ConsultationMode)
                .WithMany(m => m.Appointments)
                .HasForeignKey(x => x.ConsultationModeID_FK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Payment)
                .WithOne(p => p.Appointment)
                .HasForeignKey<PaymentEntity>(p => p.AppointmentID_FK)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x=>x.AppointmentDateTime).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Notes).HasColumnType("nvarchar(255)");

        }

    }

}
