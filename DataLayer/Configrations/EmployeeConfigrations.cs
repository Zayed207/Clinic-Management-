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
        public int EmployeeID { get; set; }
        public int TypeEmpployeeID_FK { get; set; }
        public string Titel { get; set; }
        public int PersonID_FK { get; set; }

        public int UserID_FK { get; set; }
        public string NationalID { get; set; }
        public decimal Salary { get; set; }
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.HasKey(x=>x.EmployeeID);
            builder.Property(x=>x.EmployeeID).ValueGeneratedOnAdd();
            builder.Property(x => x.NationalID). HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Salary). HasColumnType("decimal(10,2)").IsRequired();

            builder.Property(x => x.Title).HasColumnType("nvarchar(50)").IsRequired();

            builder.HasOne(x => x.EmployeeType)
                   .WithMany(c => c.Employees)
                   .HasForeignKey(x => x.EmpployeeTypeID_FK);

            builder.HasOne(x => x.person)
                   .WithOne(p => p.Employee)
                   .HasForeignKey<EmployeeEntity>(x => x.PersonID_FK).IsRequired();

           

        }
    }
}
