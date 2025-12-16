using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configrations
{
    public partial class PatientConfigrations : IEntityTypeConfiguration<PatientEntity>
    {
       
        public void Configure(EntityTypeBuilder<PatientEntity> builder)
        {
            builder.HasKey(x => x.PatientID);
            builder.Property(x => x.PatientID).ValueGeneratedOnAdd();
            
            builder.Property(x => x.EmergencyContactName).HasColumnType("nvarchar(100)");

            builder.Property(x => x.EmergencyContactPhone).HasColumnType("nvarchar(20)");
            builder.Property(x => x.RegisterDatew).HasColumnType("date").IsRequired();

            builder.HasOne(x => x.PatientPerson)
                   .WithOne(c => c.Patient)
                   .HasForeignKey<PatientEntity>(x => x.PatientPersonID_FK);

            builder.HasOne(x => x.User)
             .WithOne(c => c.Patient)
             .HasForeignKey<PatientEntity>(x => x.UserID_FK).IsRequired();
            builder.HasMany(x => x.MedicalRecords)
                   .WithOne(p => p.Patient)
                   .HasForeignKey(x => x.PatientID_FK).IsRequired();

            

        }

    }
}
