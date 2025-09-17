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
    public class PaymentConfiguration : IEntityTypeConfiguration<PaymentEntity>
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

            // Relation with Appointment
            builder.HasOne(p => p.Appointment)
                   .WithOne(a => a.Payment)
                   .HasForeignKey<PaymentEntity>(p => p.AppointmentID_FK);

            // Relation with Account (FromAccount)
            builder.HasOne(p => p.FromAccount)
                   .WithMany(a => a.PaymentsFrom)
                   .HasForeignKey(p => p.FromAccountID)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relation with Account (ToAccount)
            builder.HasOne(p => p.ToAccount)
                   .WithMany(a => a.PaymentsTo)
                   .HasForeignKey(p => p.ToAccountID)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relation with Provider
            builder.HasOne(p => p.Provider)
                   .WithMany(pr => pr.Payments)
                   .HasForeignKey(p => p.ProviderID);
        }
    }
}
