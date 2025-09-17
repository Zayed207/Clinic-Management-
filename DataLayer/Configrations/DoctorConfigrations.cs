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
    public class DoctorConfigrations : IEntityTypeConfiguration<DoctorEntity>
    {
      
        public void Configure(EntityTypeBuilder<DoctorEntity> builder)
        {
            builder.HasKey(x=>x.DoctorID);
            builder.Property(x=>x.DoctorID).ValueGeneratedOnAdd();
            builder.
                HasOne(x => x.Employee)
                .WithOne(a=>a.doctor)
                .HasForeignKey<DoctorEntity>(x=>x.Employee_ID_FK);

            builder.
                HasOne(x => x.doctorType)
                .WithMany(a => a.Doctor)
                .HasForeignKey(x => x.DoctorTypeID_FK);

            // builder.HasOne(x => x.AppointmentType).WithOne(e => e.Appointment).HasForeignKey<AppointmentEntity>(x => x.pa);

            builder.Property(x => x.MedicalLicenseNumber).IsRequired();
            builder.Property(x => x.Years_of_Experience).HasColumnType("smallint");
            builder.Property(x => x.Is_On_Call);
            builder.Property(x => x.Specialization).HasColumnType("nvarchar");
            builder.Property(x => x.Price).HasColumnType("decimal(10,2)").IsRequired();



        }
    }
}
