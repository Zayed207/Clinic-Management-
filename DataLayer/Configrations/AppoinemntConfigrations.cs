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
        //      public int Patient_ID_FK { get; set; }
        //public int Doctor_ID_FK { get; set; }
        //public int Clinic_ID_FK { get; set; }
        //public DateTime Appointment_Date_Time { get; set; }
        //public int Appointment_Duration_Minutes { get; set; }
        //public int Status_ID_FK { get; set; }
        //public int Appointment_Type_ID_FK { get; set; }
        //public int Consultation_Mode_ID_FK { get; set; }

            //public string Notes { get; set; }
   

        

        builder.HasKey(x => x.Appointment_ID);
            builder.Property(x => x.Appointment_ID).ValueGeneratedOnAdd().IsRequired();

            builder.HasOne(x => x.Doctor)
      .WithMany(d => d.Appointments)
      .HasForeignKey(x => x.Doctor_ID_FK)
      .IsRequired()
      .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Clinic)
                .WithMany(c => c.Appointments)
                .HasForeignKey(x => x.Clinic_ID_FK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(x => x.Patient_ID_FK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Status)
                .WithMany(s => s.Appointments)
                .HasForeignKey(x => x.Status_ID_FK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AppointmentType)
                .WithMany(t => t.Appointments)
                .HasForeignKey(x => x.Appointment_Type_ID_FK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ConsultationMode)
                .WithMany(m => m.Appointmentsnt)
                .HasForeignKey(x => x.Consultation_Mode_ID_FK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Payment)
                .WithOne(p => p.Appointment)
                .HasForeignKey<PaymentEntity>(p => p.AppointmentID_FK)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
