using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configrations
{
    public partial class PaymentConfiguration : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.HasKey(p => p.PaymentID);

            builder.Property(p => p.Amount)
                   .HasColumnType("decimal(10,2)")
                   .IsRequired();

            builder.Property(p => p.PaymentDate)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(p => p.Status)
                   .HasColumnType("nvarchar(50)");

           
            builder.HasOne(p => p.Appointment)
                   .WithOne(a => a.Payment)
                   .HasForeignKey<PaymentEntity>(p => p.AppointmentID_FK);

           
            builder.HasOne(p => p.Doctor)
                   .WithMany(a => a.Payments)
                   .HasForeignKey(p => p.DoctorID_FK)
                   .OnDelete(DeleteBehavior.Restrict);

           
            builder.HasOne(p => p.PatientPersonID)
                   .WithMany(a => a.Payments)
                   .HasForeignKey(p => p.PatientPersonID_FK)
                   .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasOne(p => p.Provider)
                   .WithMany(pr => pr.Payments)
                   .HasForeignKey(p => p.ProviderID_FK);

        }

    }
}
