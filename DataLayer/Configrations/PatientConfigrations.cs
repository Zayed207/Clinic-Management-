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
    public class PatientConfigrations : IEntityTypeConfiguration<PatientEntity>
    {
        public int PatientID { get; set; }

        public int PatientPersonID { get; set; }

        

        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public DateOnly RegisterDatew { get; set; }

        public void Configure(EntityTypeBuilder<PatientEntity> builder)
        {
            builder.HasKey(x => x.PatientID);
            builder.Property(x => x.PatientID).ValueGeneratedOnAdd();
            
            builder.Property(x => x.EmergencyContactName).HasColumnType("nvarchar(100)");

            builder.Property(x => x.EmergencyContactPhone).HasColumnType("nvarchar(20)");
            builder.Property(x => x.RegisterDatew).HasColumnType("datetime").IsRequired();
            builder.HasOne(x => x.Person)
                   .WithOne(c => c.patient)
                   .HasForeignKey<PatientEntity>(x => x.PatientPersonID);

            builder.HasMany(x => x.medicalRecords)
                   .WithOne(p => p.Patient)
                   .HasForeignKey(x => x.PatientID_FK);

            

        }
    }
}
