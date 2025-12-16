using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configrations.DoctorConfigrations
{
    public class DoctorConfigration : IEntityTypeConfiguration<DoctorEntity>
    {
      
        public void Configure(EntityTypeBuilder<DoctorEntity> builder)
        {
            builder.HasKey(x=>x.DoctorID);
            builder.Property(x=>x.DoctorID).ValueGeneratedOnAdd();
            builder.
                HasOne(x => x.Employee)
                .WithOne(a=>a.Doctor)
                .HasForeignKey<DoctorEntity>(x=>x.EmployeeID_FK).OnDelete(DeleteBehavior.Restrict). IsRequired();

           
            builder.
                HasOne(x => x.DoctorType)
                .WithMany(a => a.Doctors)
                .HasForeignKey(x => x.DoctorTypeID_FK);


            builder.Property(x => x.MedicalLicenseNumber).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.YearsOfExperience).HasColumnType("smallint");
            builder.Property(x => x.IsOnCall).HasColumnType("bit").IsRequired();
            builder.Property(x => x.Specialization).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Price).HasColumnType("decimal(10,2)").IsRequired();


        }
    }
}
