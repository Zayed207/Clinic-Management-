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
    public class EmployeeConfigrations : IEntityTypeConfiguration<EmployeeEntity>
    {
       
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.HasKey(x => x.EmployeeID);
            builder.Property(x => x.EmployeeID).ValueGeneratedOnAdd();
            builder.Property(x => x.NationalID).HasColumnType("varchar(50)").IsRequired();
           // builder.Property(x => x.Salary).HasColumnType("decimal(10,2)").IsRequired();

            builder.Property(x => x.Title).HasColumnType("nvarchar(50)").IsRequired();

            builder.HasOne(x => x.EmpployeeType)
                   .WithMany(c => c.Employees)
                   .HasForeignKey(x => x.EmpployeeTypeID_FK);

            builder.HasOne(x => x.Person)
                   .WithOne(p => p.Employee)
                   .HasForeignKey<EmployeeEntity>(x => x.PersonID_FK).IsRequired();

            builder.HasOne(x => x.Clinic)
                  .WithMany(p => p.Employees)
                  .HasForeignKey(x => x.ClinicID_FK).IsRequired();
            builder.HasMany(x => x.Schedules)
       .WithOne(s => s.Employee)
       .HasForeignKey(s => s.EmployeeID_FK)
       .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=>x.User).WithOne(e=>e.Employees).HasForeignKey<EmployeeEntity>(x=>x.UserID_FK).IsRequired();


        }

    }
}
